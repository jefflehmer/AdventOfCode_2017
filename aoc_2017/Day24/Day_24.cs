using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day24
{
    class Day_24
    {
        public static void Do(string srcFile)
        {
            Do_1(srcFile);
            //Do_2(srcFile);

            Console.ReadLine();
        }

        public static void Do_1(string srcFile)
        {
            var pieces = System.IO.File.ReadAllLines(srcFile);

            var components = new List<Component>(pieces.Length);
            components.AddRange(pieces.Select(piece => new Component {Ports = piece.Split('/').Select(e => new Port {Pins = int.Parse(e)}).ToList()}));


            Console.WriteLine($"Day 24.1: Strength of strongest bridge: { 0 }");
        }

        public static void Do_2(string srcFile)
        {

            Console.WriteLine($"Day 24.2: { 0 }");
        }
    }
}
