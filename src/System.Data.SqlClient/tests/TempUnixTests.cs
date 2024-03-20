// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace System.Data.SqlClient.Tests
{
    public class TempUnixTests
    {
        [Fact]
        public void TempUnixTest()
        {
            Assert.Equal(0, (int)TemporaryUnixType.Unix0);
            Assert.Equal(1, (int)TemporaryUnixType.Unix1);
        }
    }
}