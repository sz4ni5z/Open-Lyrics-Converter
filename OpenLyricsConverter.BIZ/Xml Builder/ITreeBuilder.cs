using System.Xml;

namespace OpenLyricsConverter_v2
{
    public interface ITreeBuilder
    {
        /// <summary>
        /// Container for the lyrics data in OpenLyrics xml format.
        /// </summary>
        XmlDocument OpenLyricsXml { get; set; }

        /// <summary>
        /// Method to add author property
        /// </summary>
        /// <param name="Author"></param>
        void AddAuthor(string Author);
        /// <summary>
        /// Method to add Songbook property
        /// </summary>
        /// <param name="Book"></param>
        /// <param name="Entry"></param>
        void AddSongbook(string Book, string Entry);
        /// <summary>
        /// Method to add title property
        /// </summary>
        /// <param name="Title"></param>
        void AddTitle(string Title);

        /// <summary>
        /// Method to add a verse.
        /// </summary>
        /// <param name="Verse"></param>
        void AddVerse(string Verse);

        /// <summary>
        /// Nethod for save xml file to storage
        /// </summary>
        /// <param name="path">Destination folder + filename + extension</param>
        void Save(string path);
    }
}