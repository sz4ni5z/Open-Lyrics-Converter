using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLyricsConverter.BIZ
{
    class OpenLyricsEntity : IOpenLyricsEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Songbook { get; set; }
        public int? Entry { get; set; }
        public string Verse { get; set; }
    }
}
