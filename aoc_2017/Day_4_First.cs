using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017
{
    class Day_4_First
    {
        public static void Do(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var count1 = lines.Sum(line => IsValidPassphrase1(line) ? 1 : 0);
            var count2 = lines.Sum(line => IsValidPassphrase2(line) ? 1 : 0);

            Console.Write($"Valid passphrases count1: {count1}  count2: {count2}");
            Console.ReadLine();
        }

        private static bool IsValidPassphrase1(string line)
        {
            var wordhash = new HashSet<string>();

            var words = line.Split(null);
            foreach (var word in words)
            {
                if (wordhash.Contains(word))
                    return false;

                wordhash.Add(word);
            }

            return true;
        }

        private static bool IsValidPassphrase2(string line)
        {
            var wordhash = new HashSet<string>();

            var words = line.Split(null);
            foreach (var word in words)
            {
                var sortedword = SortWord(word);
                if (wordhash.Contains(sortedword))
                    return false;

                wordhash.Add(sortedword);
            }

            return true;
        }

        private static string SortWord(string word)
        {
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            var sortedWord = new string(chars);

            return sortedWord;
        }
    }
}
