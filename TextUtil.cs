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
            return words.GroupBy(element => element, StringComparer.InvariantCultureIgnoreCase) //group all identical words, regardless of case
                        .Where(element => element.Count() > 1)
                        .ToDictionary(x => x.Key, y => y.Count());
        }

        internal static string ReadFile()
        {
            var txtFile = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            if(txtFile.Count() == 1)
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