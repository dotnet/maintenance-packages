# System.Buffers

Provides resource pooling of any type for performance-critical applications that allocate and deallocate objects frequently.

Commonly Used Types:
- System.Buffers.ArrayPool<T>

## Contribution Bar

- [We only consider fixes that unblock critical issues](https://github.com/dotnet/runtime/blob/main/src/libraries/README.md#primary-bar).
- [We don't accept refactoring changes due to new language features](https://github.com/dotnet/runtime/blob/main/src/libraries/README.md#secondary-bars)

## Deployment

[System.Buffers](https://www.nuget.org/packages/System.Buffers) is deployed as out-of-band (OOB) for .NET Standard 2.0 and .NET Framework, so it needs to be installed into projects directly.