using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day09
{
    public class Day_09
    {
        public static void Do(string srcFile)
        {
            StreamReader sr = null;
            var stack = new Stack<char>();
            const int blockSize = 100;
            var numGroups = 0;
            var totalScore = 0;
            var garbageCount = 0;
            var skip1 = false;
            var skip = false;
            var nests = 0; // i could use the stack depth if i wasn't also putting the '<' on the stack

            try
            {
                sr = File.OpenText(srcFile);

                var blockCount = 0;
                var buffer = new char[blockSize];
                while (((blockCount = sr.ReadBlock(buffer, 0, blockSize)) > 0))
                {
                    for (var i = 0; i < blockSize; i++)
                    {
                        if (buffer[i] == '\0')
                            break;

                        if (skip1)
                        {
                            skip1 = false;
                            continue;
                        }

                        if (buffer[i] == '!')
                        {
                            skip1 = true;
                            continue;
                        }

                        if (buffer[i] == '>')
                        {
                            if (stack.Peek() == '<')
                            {
                                stack.Pop();
                                skip = false;
                                continue;
                            }
                        }

                        if (skip)
                        {
                            garbageCount++;
                            continue;
                        }

                        if (buffer[i] == '<')
                        {
                            skip = true;
                            stack.Push(buffer[i]);
                            continue;
                        }

                        if (buffer[i] == '{')
                        {
                            nests++;
                            stack.Push(buffer[i]);
                            continue;
                        }

                        if (buffer[i] == '}')
                        {
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                                numGroups++;
                                totalScore += nests;
                                nests--;
                                continue;
                            }
                        }
                    }

                    if (blockCount < blockSize) // this does not work when the file size is evenly divisible by the blockSize number but while-loop above should detect it and then exit
                        break;

                    Array.Clear(buffer, 0, blockSize);
                }
            }
            catch (IOException ex)
            {
                var msg = ex.Message;
            }

            finally
            {
                sr?.Close();
            }

            Console.Write($"Day 09: numGroups: {numGroups} Total Score: {totalScore}  Amount of Garbage: {garbageCount}");
            Console.ReadLine();
        }
    }
}
