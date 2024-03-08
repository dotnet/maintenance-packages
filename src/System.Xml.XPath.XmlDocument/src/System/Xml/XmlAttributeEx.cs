// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Xml
{
    internal static class XmlAttributeEx
    {
        public static bool IsNamespace(this XmlAttribute attribute)
        {
            return Ref.Equal(attribute.NamespaceURI, XmlConst.ReservedNsXmlNs);
        }
    }
}
