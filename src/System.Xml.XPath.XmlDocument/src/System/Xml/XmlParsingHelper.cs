// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;

namespace System.Xml
{
    internal static class XmlParsingHelper
    {
        public static void ParseXmlDeclarationValue(string strValue, out string version, out string encoding, out string standalone)
        {
            version = null;
            encoding = null;
            standalone = null;
            TextReader fragmentReader = new StringReader(strValue);
            XmlReaderSettings settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
            XmlReader tempreader = XmlReader.Create(fragmentReader, settings);
            try
            {
                tempreader.Read();
                //get version info.
                if (tempreader.MoveToAttribute("version"))
                    version = tempreader.Value;
                //get encoding info
                if (tempreader.MoveToAttribute("encoding"))
                    encoding = tempreader.Value;
                //get standalone info
                if (tempreader.MoveToAttribute("standalone"))
                    standalone = tempreader.Value;
            }
            finally
            {
                tempreader.Dispose();
            }
        }
    }
}
