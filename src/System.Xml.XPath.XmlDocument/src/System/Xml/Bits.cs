// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Xml
{
    /// <summary>
    /// Contains static utility methods used to manipulate bits in a word.
    /// </summary>
    internal static class Bits
    {
        private const uint MASK_0101010101010101 = 0x55555555;
        private const uint MASK_0011001100110011 = 0x33333333;
        private const uint MASK_0000111100001111 = 0x0f0f0f0f;
        private const uint MASK_0000000011111111 = 0x00ff00ff;
        private const uint MASK_1111111111111111 = 0x0000ffff;

        /// <summary>
        /// Returns the number of 1 bits in an unsigned integer.  Counts bits by divide-and-conquer method,
        /// first computing 16 2-bit counts, then 8 4-bit counts, then 4 8-bit counts, then 2 16-bit counts,
        /// and finally 1 32-bit count.
        /// </summary>
        public static int Count(uint num)
        {
            num = (num & MASK_0101010101010101) + ((num >> 1) & MASK_0101010101010101);
            num = (num & MASK_0011001100110011) + ((num >> 2) & MASK_0011001100110011);
            num = (num & MASK_0000111100001111) + ((num >> 4) & MASK_0000111100001111);
            num = (num & MASK_0000000011111111) + ((num >> 8) & MASK_0000000011111111);
            num = (num & MASK_1111111111111111) + (num >> 16);

            return (int)num;
        }

        /// <summary>
        /// Returns true if the unsigned integer has exactly one bit set.
        /// </summary>
        public static bool ExactlyOne(uint num)
        {
            return num != 0 && (num & (num - 1)) == 0;
        }

        /// <summary>
        /// Compute the 1-based position of the least significant bit that is set, and return it (return 0 if no bits are set).
        /// (e.g. 0x1001100 will return 3, since the 3rd bit is set).
        /// </summary>
        public static int LeastPosition(uint num)
        {
            if (num == 0) return 0;
            return Count(num ^ (num - 1));
        }
    }
}
