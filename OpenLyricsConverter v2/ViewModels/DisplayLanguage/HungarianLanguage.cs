using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLyricsConverter_v2.ViewModels
{
    class HungarianLanguage : BaseViewModel, ILanguages
    {

        string _title;
        string _artist;
        string _songbook;
        string _saveButton;
        string _importButton;


        public HungarianLanguage()
        {
            _title = "Cím";
            _artist = "Szerző";
            _songbook = "Énekekkönyv";
            _saveButton = "Mentés";
            _importButton = "Importálás";
        }
        public string Title => _title;

        public string Artist => _artist;

        public string Songbook => _songbook;

        public string SaveButton => _saveButton;

        public string ImportButton => _importButton;
    }
}
