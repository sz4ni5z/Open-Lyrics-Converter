using OpenLyricsConverter.BIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OpenLyricsConverter_v2
{
    public class TreeBuilder : ITreeBuilder
    {

        #region Private Members
        private XmlDocument xdoc;
        private int versecounter;
        #endregion

        #region Properties
        /// <summary>
        /// Container for the lyrics data in OpenLyrics xml format.
        /// </summary>
        public XmlDocument OpenLyricsXml
        {
            get { return xdoc; }
            set { xdoc = value; }
        }
        #endregion


        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public TreeBuilder()
        {
            xdoc = CreateOpenLyricsTree();
        }

        public TreeBuilder(IOpenLyricsEntity entity)
        {

        }
        #endregion


        /// <summary>
        /// Method to create the backbone of xml
        /// </summary>
        /// <returns></returns>
        private XmlDocument CreateOpenLyricsTree()
        {
            XmlDocument xml = new XmlDocument();

            //add header
            XmlNode docNode = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(docNode);

            //add rootnode
            string rootname = "song";
            XmlElement root = xml.CreateElement(rootname);

            root.SetAttribute("xmlns", @"http://openlyrics.info/namespace/2009/song");
            root.SetAttribute("version", "0.8");
            root.SetAttribute("createdIn", "OpenLP 2.4.6");
            root.SetAttribute("modifiedIn", "OpenLP 2.4.6");
            root.SetAttribute("modifiedDate", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

            //add mandatory children
            root.AppendChild(xml.CreateElement("properties"));
            root.AppendChild(xml.CreateElement("lyrics"));
            xml.AppendChild(root);
            return xml;
        }

        /// <summary>
        /// Private method to ensure a parent node is existing within properties
        /// Use it before adding child nodes to the tree
        /// </summary>
        /// <param name="ParentName"></param>
        private void EnsurePropertyExistance(string ParentName)
        {
            //get property node
            XmlNode properties = xdoc.SelectSingleNode("//song/properties");
            XmlNodeList propchildren = properties.ChildNodes;

            //search for parentnode
            for (int i = 0; i < propchildren.Count; i++)
            {
                if (propchildren.Item(i).Name == ParentName)
                {
                    return;
                }
            }

            //if not created we create one
            XmlElement node = xdoc.CreateElement(ParentName);
            properties.AppendChild(node);
        }

        public void AddTitle(string Title)
        {
            EnsurePropertyExistance("titles");

            XmlElement title = xdoc.CreateElement("title");
            title.InnerText = Title;

            xdoc.SelectSingleNode("//song/properties/titles").AppendChild(title);
        }


        public void AddAuthor(string Author)
        {

            EnsurePropertyExistance("authors");
            XmlElement author = xdoc.CreateElement("author");
            author.InnerText = Author;

            xdoc.SelectSingleNode("//song/properties/authors").AppendChild(author);
        }

        public void AddSongbook(string Book, string Entry)
        {
            EnsurePropertyExistance("songbooks");
            XmlElement songbook = xdoc.CreateElement("songbook");
            songbook.SetAttribute("name", Book);
            songbook.SetAttribute("entry", Entry);

            xdoc.SelectSingleNode("//song/properties/songbooks").AppendChild(songbook);
        }

        public void AddVerse(string Verse)
        {
            //ensure parent is exist
            EnsurePropertyExistance("verseOrder");

            //separate verse
            string[] SeparatedVerse =  Utility.EmptyLineSplitter(Verse);

            //split verse to lines and add to xml one by one
            foreach (var TargetVerse in SeparatedVerse)
            {

                //split verse to lines
                string[] VerseSplittedToLines = Utility.EndOfLineSplitter(TargetVerse);

                //variable to store verse order
                string order = "v" + ++versecounter;

                //create verse element 
                XmlElement verse = xdoc.CreateElement("verse");
                verse.SetAttribute("name", order);

                //add lines to verse element
                foreach (var line in VerseSplittedToLines)
                {
  
                    XmlElement lines = xdoc.CreateElement("lines");
                    lines.InnerText = line;
                    verse.AppendChild(lines);
                }
                //add the current verse number to order node
                xdoc.SelectSingleNode("//song/properties/verseOrder").InnerText += " " + order;

                //add verse to lyrics node
                xdoc.SelectSingleNode("//song/lyrics").AppendChild(verse);
            }
        }
        public void Save(string path)
        {
            xdoc.Save(path);
        }

    }
}
