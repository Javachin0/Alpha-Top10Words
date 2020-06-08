using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Alpha_Top10Words
{
    public static class TextUtil
    {
        private const string wordPattern = @"\b\w+\b";
        internal static Dictionary<string, int> FindDuplicates(List<string> words)
        { 
            //group all identical words, regardless of case
            return words.GroupBy(element => element, StringComparer.InvariantCultureIgnoreCase)
                        .Where(element => element.Count() > 1)
                        .ToDictionary(x => x.Key, y => y.Count());
        }

        internal static string ReadFile()
        {
            var txtFile = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
#if DEBUG
            //If executing in VisualStudio debugger; .exe will be in bin/debug folder           
            Console.WriteLine("In debug");
            txtFile = Directory.GetFiles(AppContext.BaseDirectory + "../../../", "*.txt"); 
#endif
            if (txtFile.Count() == 1)
            {
                Console.WriteLine("Reading Text file..");
                return File.ReadAllText(txtFile[0]); 
            }              
            else
                throw new ArgumentException("Incorrect number of text files in Root: " + txtFile.Count());
        }
        internal static List<string> ExtractWords(string text)
        {
             Regex regex = new Regex(wordPattern);
             MatchCollection matches = regex.Matches(text);
             Console.WriteLine("Word Count: " + matches.Count);
             return matches.Cast<Match>()
                           .Select(match => match.Value)
                           .ToList();
        }
    }
}