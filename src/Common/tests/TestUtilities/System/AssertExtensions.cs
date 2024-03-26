// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xunit;

namespace System
{
    public static class AssertExtensions
    {
        private static bool IsNetFramework => RuntimeInformation.FrameworkDescription.StartsWith(".NET Framework", StringComparison.OrdinalIgnoreCase);

        public static void Throws<T>(Action action, string expectedMessage)
            where T : Exception
        {
            Assert.Equal(expectedMessage, Assert.Throws<T>(action).Message);
        }

        public static void ThrowsContains<T>(Action action, string expectedMessageContent)
            where T : Exception
        {
            Assert.Contains(expectedMessageContent, Assert.Throws<T>(action).Message);
        }

        public static T Throws<T>(string netCoreParamName, string netFxParamName, Action action)
            where T : ArgumentException
        {
            T exception = Assert.Throws<T>(action);

            if (netFxParamName == null && IsNetFramework)
            {
                // Param name varies between .NET Framework versions -- skip checking it
                return exception;
            }

            string expectedParamName =
                IsNetFramework ?
                netFxParamName : netCoreParamName;

            Assert.Equal(expectedParamName, exception.ParamName);
            return exception;
        }

        public static void Throws<T>(string netCoreParamName, string netFxParamName, Func<object> testCode)
            where T : ArgumentException
        {
            T exception = Assert.Throws<T>(testCode);

            if (netFxParamName == null && IsNetFramework)
            {
                // Param name varies between .NET Framework versions -- skip checking it
                return;
            }

            string expectedParamName =
                IsNetFramework ?
                netFxParamName : netCoreParamName;

            Assert.Equal(expectedParamName, exception.ParamName);
        }

        public static T Throws<T>(string expectedParamName, Action action)
            where T : ArgumentException
        {
            T exception = Assert.Throws<T>(action);

            Assert.Equal(expectedParamName, exception.ParamName);

            return exception;
        }

        public static T Throws<T>(Action action)
            where T : Exception
        {
            T exception = Assert.Throws<T>(action);

            return exception;
        }

        public static TException Throws<TException, TResult>(Func<TResult> func)
            where TException : Exception
        {
            object result = null;
            bool returned = false;
            try
            {
                return
                    Assert.Throws<TException>(() =>
                    {
                        result = func();
                        returned = true;
                    });
            }
            catch (Exception ex) when (returned)
            {
                string resultStr;
                if (result == null)
                {
                    resultStr = "(null)";
                }
                else
                {
                    resultStr = result.ToString();
                    if (typeof(TResult) == typeof(string))
                    {
                        resultStr = $"\"{resultStr}\"";
                    }
                }

                throw new AggregateException($"Result: {resultStr}", ex);
            }
        }

        public static T Throws<T>(string expectedParamName, Func<object> testCode)
            where T : ArgumentException
        {
            T exception = Assert.Throws<T>(testCode);

            Assert.Equal(expectedParamName, exception.ParamName);

            return exception;
        }

        public static async Task<T> ThrowsAsync<T>(string expectedParamName, Func<Task> testCode)
            where T : ArgumentException
        {
            T exception = await Assert.ThrowsAsync<T>(testCode);

            Assert.Equal(expectedParamName, exception.ParamName);

            return exception;
        }

        public static void Throws<TNetCoreExceptionType, TNetFxExceptionType>(string expectedParamName, Action action)
            where TNetCoreExceptionType : ArgumentException
            where TNetFxExceptionType : Exception
        {
            if (IsNetFramework)
            {
                // Support cases where the .NET Core exception derives from ArgumentException
                // but the .NET Framework exception is not.
                if (typeof(ArgumentException).IsAssignableFrom(typeof(TNetFxExceptionType)))
                {
                    Exception exception = Assert.Throws<TNetFxExceptionType>(action);
                    Assert.Equal(expectedParamName, ((ArgumentException)exception).ParamName);
                }
                else
                {
                    AssertExtensions.Throws<TNetFxExceptionType>(action);
                }
            }
            else
            {
                AssertExtensions.Throws<TNetCoreExceptionType>(expectedParamName, action);
            }
        }

        public static Exception Throws<TNetCoreExceptionType, TNetFxExceptionType>(Action action)
            where TNetCoreExceptionType : Exception
            where TNetFxExceptionType : Exception
        {
            return Throws(typeof(TNetCoreExceptionType), typeof(TNetFxExceptionType), action);
        }

        public static Exception Throws(Type netCoreExceptionType, Type netFxExceptionType, Action action)
        {
            if (IsNetFramework)
            {
                return Assert.Throws(netFxExceptionType, action);
            }
            else
            {
                return Assert.Throws(netCoreExceptionType, action);
            }
        }

        public static void Throws<TNetCoreExceptionType, TNetFxExceptionType>(string netCoreParamName, string netFxParamName, Action action)
            where TNetCoreExceptionType : ArgumentException
            where TNetFxExceptionType : ArgumentException
        {
            if (IsNetFramework)
            {
                Throws<TNetFxExceptionType>(netFxParamName, action);
            }
            else
            {
                Throws<TNetCoreExceptionType>(netCoreParamName, action);
            }
        }
    }
}
