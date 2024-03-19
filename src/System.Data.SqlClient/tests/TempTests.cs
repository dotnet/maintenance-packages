// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Data.SqlClient.Tests
{
    public class TempTests
    {
        [Fact]
        public void TempTest()
        {
            Assert.Equal(0, (int)ApplicationIntent.ReadWrite);
            Assert.Equal(1, (int)ApplicationIntent.ReadOnly);
        }
    }
}