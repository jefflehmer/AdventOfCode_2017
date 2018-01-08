using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day25
{
    class Day_25
    {
        public static void Do(string srcFile)
        {
            var rawBlueprints = System.IO.File.ReadAllLines(srcFile);
            var regex = Regex.Match(rawBlueprints[0], @"Begin in state (?<startState>.+).$");
            var startState = regex.Groups["startState"].ToString();
            regex = Regex.Match(rawBlueprints[1], @"Perform a diagnostic checksum after (?<numSteps>.+) steps.$");
            var numSteps = int.Parse(regex.Groups["numSteps"].ToString());

            var machine = new Turing(startState, rawBlueprints);

            for (var i = 0; i < numSteps; i++)
                machine.MoveNext();

            Console.WriteLine($"Day 25.1: Diagnostic checksum: { machine.Checksum }");
            Console.ReadLine();
        }

        public static void Do_2(string srcFile)
        {
            var pieces = System.IO.File.ReadAllLines(srcFile);


            Console.WriteLine($"Day 25.2: Diagnostic checksum: { 0 }");
        }
    }
}
