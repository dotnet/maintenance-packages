// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.Versioning;
using Xunit;

namespace System.Data.SqlClient.Tests
{
    public class TempTests
    {
        [Fact]
        public void TempTest()
        {
            Assert.Equal(0, (int)TemporaryType.Val0);
            Assert.Equal(1, (int)TemporaryType.Val1);
        }
    }
}