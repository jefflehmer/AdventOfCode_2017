using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017
{
    class Day_2_First
    {
        public static void Do(string srcFile)
        {
            StreamReader sr = null;
            var vals = new List<int>();
            var idx = 0;

            try
            {
                sr = File.OpenText(srcFile);
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {
                    idx++;
                    vals.Add(GetEvenlyDivisibleRange(line));
                    //vals.Add(GetLargestRange(line));
                }
            }
            catch (IOException ex)
            {
                var msg = ex.Message;
                // handle please 
            }

            finally
            {
                // clean up 
                sr?.Close();
            }

            Console.Write($"Lines: {idx}  Checksum: {vals.Aggregate((a, b) => b + a)}");
            Console.ReadLine();
        }

        private static int GetEvenlyDivisibleRange(string line)
        {
            var nums = line.Split().Select(int.Parse).ToArray();
            var numsCount = nums.Length;
            for (int i = 0; i < numsCount; i++)
            {
                for (int j = i + 1; j < numsCount; j++)
                {
                    var lower = (nums[i] < nums[j]) ? i : j;
                    var hiyer = (nums[i] > nums[j]) ? i : j;
                    var mod = nums[hiyer] % nums[lower];
                    if (mod == 0)
                    {
                        Console.WriteLine($"{nums[hiyer]} % {nums[lower]} => {nums[hiyer] / nums[lower]}");
                        return nums[hiyer] / nums[lower];
                    }
                }
            }

            return 0;
        }

        private static int GetLargestRange(string line)
        {
            var low = 9999;
            var high = -1;
            var nums = line.Split().Select(int.Parse);
            foreach (var num in nums)
            {
                if (num < low) low = num;
                if (num > high) high = num;
            }
            Console.WriteLine($"{high} - {low} = {high - low}");

            return high - low;
        }
    }
}
