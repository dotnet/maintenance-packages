// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace XPathTests.Common
{
    public static partial class Utils
    {
        private readonly static ICreateNavigator _navigatorCreator = new CreateNavigatorFromXmlDocument();
        public readonly static string ResourceFilesPath = "System.Xml.XPath.XmlDocument.Tests.TestData.";
    }
}
