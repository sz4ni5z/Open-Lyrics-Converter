using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLyricsConverter.BIZ
{
    public static class Utility
    {
        /// <summary>
        /// Method to split a string based on empty lines
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string[] EmptyLineSplitter(string Input)
        {
            return Input.Split(
                new string[]
                {
                    Environment.NewLine + Environment.NewLine,
                    Environment.NewLine + " " + Environment.NewLine
                },
            StringSplitOptions.RemoveEmptyEntries);
        }


        /// <summary>
        /// Method to split a string based on end line character
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string[] EndOfLineSplitter(string Input)
        {
            return Input.Split(
    new string[]
    {
                    Environment.NewLine,
                    Environment.NewLine + " "
    },
StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
