## About

Provides a `DispatchProxy` class to dynamically create proxy instances that implement a specified interface.

## Key Features

Method invocations on a generated proxy instance are dispatched to a `Invoke()` method. Having a single invoke method allows centralized handling for scenarios such as logging, error handling and caching.

## How to Use

Create the proxy class that derives from `DispatchProxy`, override `Invoke()` and call one of the static `DispatchProxy.Create()` methods to generate the proxy type.

The example below intercepts calls to the `ICallMe` interface and logs them.

```c#
class Program
{
    static void Main(string[] args)
    {
        ICallMe proxy = LoggingDispatchProxy.Create<ICallMe>(new MyClass());
        proxy.CallMe("Hello!");
    }
}

public interface ICallMe
{
    void CallMe(string name);
}

public class MyClass : ICallMe
{
    public void CallMe(string message)
    {
        Console.WriteLine($"Inside the called method with input '{message}'");
    }
}

public class LoggingDispatchProxy : DispatchProxy
{
    private ICallMe _target;

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        Console.WriteLine($"Calling method: '{targetMethod.Name}' with arguments: '{string.Join(", ", args)}'");
        object result = targetMethod.Invoke(_target, args);
        Console.WriteLine($"Called method: '{targetMethod.Name}'.");
        return result;
    }

    public static T Create<T>(T target) where T : class
    {
        LoggingDispatchProxy proxy = DispatchProxy.Create<T, LoggingDispatchProxy>() as LoggingDispatchProxy;
        proxy._target = (ICallMe)target;
        return proxy as T;
    }
}
```

## Main Types

The main types provided by this library are:

- System.Reflection.DispatchProxy

## Additional Documentation

- API reference can be found in: https://learn.microsoft.com/en-us/dotnet/api/system.reflection.dispatchproxy

## License

System.Reflection.DispatchProxy is released as open source under the [MIT license](https://licenses.nuget.org/MIT).
