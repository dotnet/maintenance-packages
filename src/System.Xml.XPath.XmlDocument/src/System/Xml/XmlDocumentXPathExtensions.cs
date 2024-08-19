// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Xml.XPath;

namespace System.Xml
{
    /// <summary>
    /// Provides extension methods for the XmlDocument and XmlNode for document navigation.
    /// </summary>
    public static class XmlDocumentXPathExtensions
    {
        private class XmlDocumentNavigable : IXPathNavigable
        {
            private XmlNode _node;
            public XmlDocumentNavigable(XmlNode n)
            {
                _node = n;
            }

            public XPathNavigator CreateNavigator()
            {
                return _node.CreateNavigator();
            }
        }

        /// <summary>
        /// Selects a list of nodes matching the specified XPath expression.
        /// </summary>
        /// <param name="node">The node where the navigator is initially positioned.</param>
        /// <param name="xpath">The XPath expression to match.</param>
        /// <returns>A collection of nodes that match the specified XPath expression.</returns>
        public static XmlNodeList SelectNodes(this XmlNode node, string xpath)
        {
            return node.SelectNodes(xpath);
        }

        /// <summary>
        /// Selects a list of nodes matching the specified XPath expression. Any prefixes found in the XPath expression are resolved using the supplied namespace manager.
        /// </summary>
        /// <param name="node">The node where the navigator is initially positioned.</param>
        /// <param name="xpath">The XPath expression to match.</param>
        /// <param name="nsmgr">A namespace manager to resolve XPath expression prefix namespaces.</param>
        /// <returns>A collection of nodes that match the specified XPath expression.</returns>
        public static XmlNodeList SelectNodes(this XmlNode node, string xpath, XmlNamespaceManager nsmgr)
        {
            return node.SelectNodes(xpath, nsmgr);
        }

        /// <summary>
        /// Selects the first node that matches the XPath expression.
        /// </summary>
        /// <param name="node">The node where the navigator is initially positioned.</param>
        /// <param name="xpath">The XPath expression to match.</param>
        /// <returns>The first node that matches the XPath query, or null if no matching node is found.</returns>
        public static XmlNode SelectSingleNode(this XmlNode node, string xpath)
        {
            return node.SelectSingleNode(xpath);
        }

        /// <summary>
        /// Selects the first node that matches the XPath expression. Any prefixes found in the XPath expression are resolved using the supplied namespace manager.
        /// </summary>
        /// <param name="node">The node where the navigator is initially positioned.</param>
        /// <param name="xpath">The XPath expression to match.</param>
        /// <param name="nsmgr">A namespace manager to resolve XPath expression prefix namespaces.</param>
        /// <returns>The first node that matches the XPath query, or null if no matching node is found.</returns>
        public static XmlNode SelectSingleNode(this XmlNode node, string xpath, XmlNamespaceManager nsmgr)
        {
            return node.SelectSingleNode(xpath, nsmgr);
        }

        /// <summary>
        /// Creates an XPath navigator for navigating the specified node.
        /// </summary>
        /// <param name="node">The node where the navigator is initially positioned.</param>
        /// <returns>An XPath navigator object.</returns>
        public static XPathNavigator CreateNavigator(this XmlNode node)
        {
            return node.CreateNavigator();
        }

        /// <summary>
        /// Creates an IXPathNavigable instance used for producing navigators.
        /// </summary>
        /// <param name="node">The node in which the implementation should position newly created navigators.</param>
        /// <returns>An IXPathNavigable instance</returns>
        public static IXPathNavigable ToXPathNavigable(this XmlNode node)
        {
            return new XmlDocumentNavigable(node);
        }

        /// <summary>
        /// Creates a new XPath navigator object for navigating the specified document.
        /// </summary>
        /// <param name="document">The document from which the XPath navigator is created.</param>
        /// <returns>An XPath navigator object.</returns>
        public static XPathNavigator CreateNavigator(this XmlDocument document)
        {
            return document.CreateNavigator();
        }

        /// <summary>
        /// Creates an XPath navigator object for navigating the specified document positioned on the specified node.
        /// </summary>
        /// <param name="document">The document from which the XPath navigator is created.</param>
        /// <param name="node">The node where the navigator is initially positioned.</param>
        /// <returns>An XPath navigator object.</returns>
        public static XPathNavigator CreateNavigator(this XmlDocument document, XmlNode node)
        {
            Debug.Assert(node == document || node?.OwnerDocument == document);
            return node.CreateNavigator();
        }
    }
}
