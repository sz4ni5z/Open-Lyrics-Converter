namespace OpenLyricsConverter.BIZ
{
    public interface IOpenLyricsEntity
    {
        string Author { get; set; }
        int? Entry { get; set; }
        string Songbook { get; set; }
        string Title { get; set; }
        string Verse { get; set; }
    }
}