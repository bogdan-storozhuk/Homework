using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ConsoleApplication23_1
{
    internal class Library
    {
        private readonly string _path;

        public Library(string path)
        {
          _path = path;
        }

        public void Add(Book book)
        {
            if (!File.Exists(_path))
            {
                var xmlTextWriter = new XmlTextWriter(_path, null);
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteStartElement("ArrayOfBooks");
                xmlTextWriter.WriteStartElement("book");
                xmlTextWriter.WriteStartElement("name");
                xmlTextWriter.WriteString(book.Name);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("code");
                xmlTextWriter.WriteString(book.Code);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteStartElement("author");
                xmlTextWriter.WriteString(book.Author);
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.Close();
            }
            else
            {
                var xmlDocument = new XmlDocument();
                var xPathNavigator = xmlDocument.CreateNavigator();
                xmlDocument.Load(_path);
                xPathNavigator.MoveToChild("ArrayOfBooks", "");
                xPathNavigator.MoveToChild("book", "");
                xPathNavigator.InsertBefore("<book></book>");
                xPathNavigator.MoveToFirst();
                xPathNavigator.AppendChild(string.Format("<name>{0}</name>", book.Name));
                xPathNavigator.AppendChild(string.Format("<code>{0}</code>", book.Code));
                xPathNavigator.AppendChild(string.Format("<author>{0}</author>", book.Author));
                xmlDocument.Save("file.xml");
            }
        }

        public void Delete(string name)
            {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.Load(_path);
                    XmlNode root = xmlDocument.DocumentElement;
                    var node = root.SelectSingleNode(
                        string.Format("book[name='{0}']",
                            name));
                    root.RemoveChild(node);
                    xmlDocument.Save(_path);
            }

        public void Search(string name)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(_path);
            XmlNode root = xmlDocument.DocumentElement;
            var node = root.SelectSingleNode(
                string.Format("book[name='{0}']",
                    name));
            Console.WriteLine(node.InnerXml);
            xmlDocument.Save(_path);
        }

        public void Select(string XPathExpression)
        {
            var xPathDocument = new XPathDocument(_path);
            var xPathNavigator = xPathDocument.CreateNavigator();
            var expr = xPathNavigator.Compile(XPathExpression);
            var iterator2 = xPathNavigator.Select(expr);

            while (iterator2.MoveNext())
            {
                Console.WriteLine(iterator2.Current);
            }
        }
        }
    }
                                                                                                        