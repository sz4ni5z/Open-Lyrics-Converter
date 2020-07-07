using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLyricsConverter_v2
{
    interface ILanguages
    {
        string Title { get;}
        string Artist { get; }
        string Songbook { get; }
        string SaveButton { get; }

        string ImportButton { get; }

    }
}
