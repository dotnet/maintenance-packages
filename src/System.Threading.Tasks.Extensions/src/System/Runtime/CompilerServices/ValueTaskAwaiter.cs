// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace System.Runtime.CompilerServices
{
    /// <summary>Provides an awaiter for a <see cref="ValueTask"/>.</summary>
    public readonly struct ValueTaskAwaiter : ICriticalNotifyCompletion
    {
        /// <summary>Shim used to invoke an <see cref="Action"/> passed as the state argument to a <see cref="Action{Object}"/>.</summary>
        internal static readonly Action<object> s_invokeActionDelegate = state =>
        {
            if (!(state is Action action))
            {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.state);
                return;
            }

            action();
        };
        /// <summary>The value being awaited.</summary>
        private readonly ValueTask _value;

        /// <summary>Initializes the awaiter.</summary>
        /// <param name="value">The value to be awaited.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ValueTaskAwaiter(ValueTask value) => _value = value;

        /// <summary>Gets whether the <see cref="ValueTask"/> has completed.</summary>
        public bool IsCompleted
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _value.IsCompleted;
        }

        /// <summary>Gets the result of the ValueTask.</summary>
        [StackTraceHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetResult() => _value.ThrowIfCompletedUnsuccessfully();

        /// <summary>Schedules the continuation action for this ValueTask.</summary>
        public void OnCompleted(Action continuation)
        {
            object obj = _value._obj;
            Debug.Assert(obj == null || obj is Task || obj is IValueTaskSource);

            if (obj is Task t)
            {
                t.GetAwaiter().OnCompleted(continuation);
            }
            else if (obj != null)
            {
                Unsafe.As<IValueTaskSource>(obj).OnCompleted(s_invokeActionDelegate, continuation, _value._token, ValueTaskSourceOnCompletedFlags.UseSchedulingContext | ValueTaskSourceOnCompletedFlags.FlowExecutionContext);
            }
            else
            {
                ValueTask.CompletedTask.GetAwaiter().OnCompleted(continuation);
            }
        }

        /// <summary>Schedules the continuation action for this ValueTask.</summary>
        public void UnsafeOnCompleted(Action continuation)
        {
            object obj = _value._obj;
            Debug.Assert(obj == null || obj is Task || obj is IValueTaskSource);

            if (obj is Task t)
            {
                t.GetAwaiter().UnsafeOnCompleted(continuation);
            }
            else if (obj != null)
            {
                Unsafe.As<IValueTaskSource>(obj).OnCompleted(s_invokeActionDelegate, continuation, _value._token, ValueTaskSourceOnCompletedFlags.UseSchedulingContext);
            }
            else
            {
                ValueTask.CompletedTask.GetAwaiter().UnsafeOnCompleted(continuation);
            }
        }
    }

    /// <summary>Provides an awaiter for a <see cref="ValueTask{TResult}"/>.</summary>
    public readonly struct ValueTaskAwaiter<TResult> : ICriticalNotifyCompletion
    {
        /// <summary>The value being awaited.</summary>
        private readonly ValueTask<TResult> _value;

        /// <summary>Initializes the awaiter.</summary>
        /// <param name="value">The value to be awaited.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ValueTaskAwaiter(ValueTask<TResult> value) => _value = value;

        /// <summary>Gets whether the <see cref="ValueTask{TResult}"/> has completed.</summary>
        public bool IsCompleted
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _value.IsCompleted;
        }

        /// <summary>Gets the result of the ValueTask.</summary>
        [StackTraceHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TResult GetResult() => _value.Result;

        /// <summary>Schedules the continuation action for this ValueTask.</summary>
        public void OnCompleted(Action continuation)
        {
            object obj = _value._obj;
            Debug.Assert(obj == null || obj is Task<TResult> || obj is IValueTaskSource<TResult>);

            if (obj is Task<TResult> t)
            {
                t.GetAwaiter().OnCompleted(continuation);
            }
            else if (obj != null)
            {
                Unsafe.As<IValueTaskSource<TResult>>(obj).OnCompleted(ValueTaskAwaiter.s_invokeActionDelegate, continuation, _value._token, ValueTaskSourceOnCompletedFlags.UseSchedulingContext | ValueTaskSourceOnCompletedFlags.FlowExecutionContext);
            }
            else
            {
                ValueTask.CompletedTask.GetAwaiter().OnCompleted(continuation);
            }
        }

        /// <summary>Schedules the continuation action for this ValueTask.</summary>
        public void UnsafeOnCompleted(Action continuation)
        {
            object obj = _value._obj;
            Debug.Assert(obj == null || obj is Task<TResult> || obj is IValueTaskSource<TResult>);

            if (obj is Task<TResult> t)
            {
                t.GetAwaiter().UnsafeOnCompleted(continuation);
            }
            else if (obj != null)
            {
                Unsafe.As<IValueTaskSource<TResult>>(obj).OnCompleted(ValueTaskAwaiter.s_invokeActionDelegate, continuation, _value._token, ValueTaskSourceOnCompletedFlags.UseSchedulingContext);
            }
            else
            {
                ValueTask.CompletedTask.GetAwaiter().UnsafeOnCompleted(continuation);
            }
        }
    }
}
