// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;
using System.Reflection;

namespace XPathTests.Common
{
    public static class FileHelper
    {
        public static Stream CreateStreamFromFile(string xml)
        {
            var xmlPath = Utils.ResourceFilesPath + xml;
            Stream s = typeof(FileHelper).GetTypeInfo().Assembly.GetManifestResourceStream(xmlPath);
            if (s == null)
            {
                throw new Exception("Couldn't find resource.");
            }
            return s;
        }
    }
}
