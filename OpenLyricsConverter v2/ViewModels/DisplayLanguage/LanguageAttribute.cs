using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLyricsConverter_v2
{
    [System.AttributeUsage(System.AttributeTargets.Class)] //we using it only classes
    class LanguageAttribute : Attribute
    {
        string _name;

        public LanguageAttribute(string Name)
        {
            _name = Name;
        }

        public string GetName()
        {
            return _name;
        }


    }
}
