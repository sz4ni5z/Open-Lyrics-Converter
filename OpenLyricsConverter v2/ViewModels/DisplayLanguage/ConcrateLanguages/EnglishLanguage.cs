using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLyricsConverter_v2
{
    [LanguageAttribute("English")]
    class EnglishLanguage : BaseViewModel, ILanguages
    {

        string _title;
        string _artist;
        string _songbook;
        string _saveButton;
        string _importButton;
        string _language;


        public EnglishLanguage()
        {
            _title = "Title";
            _artist = "Artist";
            _songbook = "Songbook";
            _saveButton = "Save";
            _importButton = "Import";
            _language = "Language";
        }
        public string Title => _title;

        public string Artist => _artist;

        public string Songbook => _songbook;

        public string SaveButton => _saveButton;

        public string ImportButton => _importButton;

        public string Language => _language;
    }

}
