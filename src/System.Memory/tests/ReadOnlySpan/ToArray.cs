// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace System.SpanTests
{
    public static partial class ReadOnlySpanTests
    {
        [Fact]
        public static void ToArray1()
        {
            int[] a = { 91, 92, 93 };
            ReadOnlySpan<int> span = new ReadOnlySpan<int>(a);
            int[] copy = span.ToArray();
            Assert.Equal<int>(a, copy);
            Assert.NotSame(a, copy);
        }

        [Fact]
        public static void ToArrayWithIndex()
        {
            int[] a = { 91, 92, 93, 94, 95 };
            var span = new Span<int>(a);
            int[] copy = span.Slice(2).ToArray();

            Assert.Equal<int>(new int[] { 93, 94, 95 }, copy);
        }

        [Fact]
        public static void ToArrayWithIndexAndLength()
        {
            int[] a = { 91, 92, 93 };
            var span = new Span<int>(a, 1, 1);
            int[] copy = span.ToArray();
            Assert.Equal<int>(new int[] { 92 }, copy);
        }

        [Fact]
        public static void ToArrayEmpty()
        {
            ReadOnlySpan<int> span = ReadOnlySpan<int>.Empty;
            int[] copy = span.ToArray();
            Assert.Empty(copy);
        }
    }
}
