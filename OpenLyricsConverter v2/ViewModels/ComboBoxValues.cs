using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLyricsConverter_v2
{
    class ComboBoxValues : BaseViewModel
    {
        int[] _comboboxvalues = Enumerable.Range(1, 1000).ToArray();

        public int[] ComboBoxValueArray { get => _comboboxvalues; }

        public int ComboBoxValuePointer { get; set; }
    }
}
