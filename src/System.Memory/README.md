# System.Memory

Provides types for efficient representation and pooling of managed, stack, and native memory segments and sequences of such segments, along with primitives to parse and format UTF-8 encoded text stored in those memory segments.

Commonly Used Types:
- System.Span
- System.ReadOnlySpan
- System.Memory
- System.ReadOnlyMemory
- System.Buffers.MemoryPool
- System.Buffers.ReadOnlySequence
- System.Buffers.Text.Utf8Parser
- System.Buffers.Text.Utf8Formatter

## Contribution Bar

- [We only consider fixes that unblock critical issues](https://github.com/dotnet/runtime/blob/main/src/libraries/README.md#primary-bar).
- [We don't accept refactoring changes due to new language features](https://github.com/dotnet/runtime/blob/main/src/libraries/README.md#secondary-bars)

## Deployment

[System.Memory](https://www.nuget.org/packages/System.Memory) is deployed as out-of-band (OOB) for .NET Standard 2.0 and .NET Framework 4.6.2+, so it and needs to be installed into projects directly.