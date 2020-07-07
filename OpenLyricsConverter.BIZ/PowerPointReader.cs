using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.PowerPoint;
using System.IO;

namespace OpenLyricsConverter_v2
{
    class PowerPointReader
    {
        Microsoft.Office.Interop.PowerPoint.Slides slides;
        Microsoft.Office.Interop.PowerPoint._Slide slide;
        Microsoft.Office.Interop.PowerPoint.TextRange objText;

        public PowerPointReader(string DirectoryPath, string OutputDirectory)
        {
            string[] presentations = Get_Presentation_From_Directory(DirectoryPath);

            var pptapp = new Application();
            var presentation = pptapp.Presentations;
            foreach (var i in presentations)
            {
                var file = presentation.Open(i);
                var slides = file.Slides;
                var something = slides.Count;

                var iterator = slides.GetEnumerator();

                while(iterator.MoveNext())
                {

                } 
            }

        }

        private string[] Get_Presentation_From_Directory(string DirectoryPath)
        {
            //get all files
            return Directory.GetFiles(DirectoryPath, ".ppt");
        }
        private void openfile()
        {

        }
    }
}
