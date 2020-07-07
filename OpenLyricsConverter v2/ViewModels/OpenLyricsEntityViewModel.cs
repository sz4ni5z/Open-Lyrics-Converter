using OpenLyricsConverter.BIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLyricsConverter_v2
{
    class OpenLyricsEntityViewModel : BaseViewModel, IOpenLyricsEntity
    {
        public string Author { get; set; }
        public int? Entry { get; set; }
        public string Songbook { get; set; }
        public string Title { get; set; }
        public string Verse { get; set; }
    }
}
