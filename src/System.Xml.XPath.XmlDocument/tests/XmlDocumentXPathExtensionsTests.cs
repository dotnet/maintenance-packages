// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace System.Xml.XPathXmlDocument.Tests;

/// <summary>
/// These tests are just basic functional tests for XmlDocumentXPathExtensions
/// We explicitly call the methods on te static extension type rather than target types
/// to ensure we bind to the XmlDocumentXPathExtensions.
/// These are just basic tests to ensure the extension methods are functional.
/// </summary>
public class XmlDocumentXPathExtensionsTests
{
    private static readonly XmlDocument xmlDocument = new();
    
    static XmlDocumentXPathExtensionsTests()
    {
        xmlDocument.LoadXml("""
            <?xml version="1.0"?>
            <!-- A fragment of a book store inventory database -->
            <bookstore xmlns:bk="urn:samples">
                <book genre="novel" publicationdate="1997" bk:ISBN="1-861001-57-8">
                    <title>Pride And Prejudice</title>
                    <author>
                    <first-name>Jane</first-name>
                    <last-name>Austen</last-name>
                    </author>
                    <price>24.95</price>
                </book>
                <book genre="novel" publicationdate="1992" bk:ISBN="1-861002-30-1">
                    <title>The Handmaid's Tale</title>
                    <author>
                    <first-name>Margaret</first-name>
                    <last-name>Atwood</last-name>
                    </author>
                    <price>29.95</price>
                </book>
                <book genre="novel" publicationdate="1991" bk:ISBN="1-861001-57-6">
                    <title>Emma</title>
                    <author>
                    <first-name>Jane</first-name>
                    <last-name>Austen</last-name>
                    </author>
                    <price>19.95</price>
                </book>
                <book genre="novel" publicationdate="1982" bk:ISBN="1-861001-45-3">
                    <title>Sense and Sensibility</title>
                    <author>
                    <first-name>Jane</first-name>
                    <last-name>Austen</last-name>
                    </author>
                    <price>19.95</price>
                </book>
            </bookstore>
            """);
    }

    [Fact]
    public static void SelectNodes()
    {
        var nodeList = XmlDocumentXPathExtensions.SelectNodes(xmlDocument.DocumentElement, "descendant::book[author/last-name='Austen']");
        Assert.Equal(3, nodeList.Count);
    }

    [Fact]
    public static void SelectNodes_nsmgr()
    {
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
        nsmgr.AddNamespace("bk", "urn:samples");
        var nodeList = XmlDocumentXPathExtensions.SelectNodes(xmlDocument.DocumentElement, "/bookstore/book/@bk:ISBN", nsmgr);
        Assert.Equal(4, nodeList.Count);
    }

    [Fact]
    public static void SelectSingleNode()
    {
        var node = XmlDocumentXPathExtensions.SelectSingleNode(xmlDocument.DocumentElement, "descendant::book[author/last-name='Atwood']");
        Assert.NotNull(node);   
    }

    [Fact]
    public static void SelectSingleNode_nsmgr()
    {
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
        nsmgr.AddNamespace("bk", "urn:samples");
        var node = XmlDocumentXPathExtensions.SelectSingleNode(xmlDocument.DocumentElement, "descendant::book[@bk:ISBN='1-861001-45-3'] ", nsmgr);
        Assert.NotNull(node);
    }

    [Fact]
    public static void CreateNavigator_node()
    {
        var navigator = XmlDocumentXPathExtensions.CreateNavigator(xmlDocument.DocumentElement);
        Assert.NotNull(navigator);
    }

    [Fact]
    public static void CreateNavigator_document()
    {
        var navigator = XmlDocumentXPathExtensions.CreateNavigator(xmlDocument);
        Assert.NotNull(navigator);
    }

    [Fact]
    public static void CreateNavigator_document_node()
    {
        var navigator = XmlDocumentXPathExtensions.CreateNavigator(xmlDocument, xmlDocument.DocumentElement);
        Assert.NotNull(navigator);
    }

    [Fact]
    public static void ToXPathNavigable()
    {
        var navigable = XmlDocumentXPathExtensions.ToXPathNavigable(xmlDocument.DocumentElement);
        Assert.NotNull(navigable);
    }   
}
