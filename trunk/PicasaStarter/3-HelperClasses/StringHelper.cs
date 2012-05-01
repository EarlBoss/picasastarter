using System;
using System.Collections.Generic;
using System.Text;

namespace PicasaStarter
{
    public static class StringHelper
    {
        public static string DivideInLines(string text, int maxCharactersPerLine)
        {
            if (text.Length <= maxCharactersPerLine)
                return text;

            string returnString = "";
            string[] words = text.Split(' ');

            string line = "";
            for (int i = 0 ; i < words.Length ; i++)
            {
                // If line is empty at the moment, add the word
                if(line.Length == 0)
                    line += words[i];
                // If enough place in current line, add it...
                else if (line.Length + words[i].Length < maxCharactersPerLine)
                    line += " " + words[i];
                // Else start a new line...
                else
                {
                    returnString += line + Environment.NewLine;
                    line = words[i];
                }
            }
            // Add the last line...
            returnString += line;

            return returnString;
        }
    }
}
