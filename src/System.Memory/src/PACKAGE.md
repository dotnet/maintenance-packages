## About

<!-- A description of the package and where one can find more documentation -->

Provides types for efficient representation and pooling of managed, stack, and native memory segments and sequences of such segments, along with primitives to parse and format UTF-8 encoded text stored in those memory segments.

## Key Features

<!-- The key features of this package -->
Easily, safely and efficiently manipulate stack and heap memory.

## How to Use

<!-- A compelling example on how to use this package with code, as well as any specific guidelines for when to use the package -->

Span:

```cs
// Create a span over an array.
var array = new byte[100];
var arraySpan = new Span<byte>(array);

byte data = 0;
for (int ctr = 0; ctr < arraySpan.Length; ctr++)
    arraySpan[ctr] = data++;

int arraySum = 0;
foreach (var value in array)
    arraySum += value;

Console.WriteLine($"The sum is {arraySum}");
// Output:  The sum is 4950
```

Memory:

```cs
// Create a memory block of integers
int[] numbers = { 1, 2, 3, 4, 5 };
Memory<int> memory = new Memory<int>(numbers);

// Access and modify the elements in the memory block
memory.Span[2] = 10;

// Iterate over the memory block
foreach (var number in memory.Span)
{
    Console.WriteLine(number);
}

// Output: 1 2 10 4 5
```

ReadOnlySpan:

```cs
// Create a read-only span over an array.
int[] numbers = { 1, 2, 3, 4, 5 };
ReadOnlySpan<int> span = numbers;

// Iterate over the span and print each element.
foreach (var number in span)
{
    Console.WriteLine(number);
}

// Output: 1 2 3 4 5
```

ReadOnlyMemory:

```cs
// Create a read-only memory block of integers
int[] numbers = { 1, 2, 3, 4, 5 };
ReadOnlyMemory<int> memory = new ReadOnlyMemory<int>(numbers);

// Access and read the elements in the memory block
for (int i = 0; i < memory.Length; i++)
{
    Console.WriteLine(memory.Span[i]);
}

// Output: 1 2 3 4 5
```

## Main Types

<!-- The main types provided in this library -->

The main types provided by this library are:

* System.Span
* System.ReadOnlySpan
* System.Memory
* System.ReadOnlyMemory
* System.MemoryExtensions
* System.Buffers.MemoryPool
* System.Buffers.ReadOnlySequence
* System.Buffers.Text.Utf8Parser
* System.Buffers.Text.Utf8Formatter

## Additional Documentation

* [Conceptual documentation](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/)
* [System namespace API documentation](https://learn.microsoft.com/en-us/dotnet/api/system)
* [System.Buffers namespace API documentation](https://learn.microsoft.com/en-us/dotnet/api/system.buffers)


## Related Packages

<!-- The related packages associated with this package -->

* [System.Buffers](https://www.nuget.org/packages/System.Buffers)
* [System.Runtime.CompilerServices.Unsafe](https://www.nuget.org/packages/System.Runtime.CompilerServices.Unsafe)

## Feedback & Contributing

<!-- How to provide feedback on this package and contribute to it -->

System.Memory is released as open source under the [MIT license](https://licenses.nuget.org/MIT). Bug reports and contributions are welcome at [the GitHub repository](https://github.com/dotnet/runtime).