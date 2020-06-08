using System;
using System.Linq;
using System.IO;

namespace Alpha_Top10Words
{
    class Program
    {
        
        private static string directory = Directory.GetCurrentDirectory();
        static void Main(string[] args)
        {
            try
            {
                DisplayWordCount();    
            }       
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private static void DisplayWordCount()
        {
            string file = TextUtil.ReadFile();
            var words = TextUtil.ExtractWords(file);
            //Display Top 10 Results
            var results = TextUtil.FindDuplicates(words)
                            .OrderByDescending(count => count.Value)
                            .Take(10);
            int i = 1;
            foreach (var result in results)
            {
                Console.WriteLine($"{i}. '{result.Key}' appears: {result.Value} times");
                i++;
            }
        }
    }
}
