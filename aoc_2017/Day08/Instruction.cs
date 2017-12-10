using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day08
{
    public class Instruction
    {
        public string RegisterName { get; set; }
        public bool IncDec { get; set; }
        public int Increment { get; set; }
        public Condition Condition { get; set; }

        public Instruction(string line)
        {
            //string sample = @"ytr dec -258 if xzn < 9";
            var match = Regex.Match(line, @"(?<register>.*) (?<incdec>.*) (?<increment>.*) if (?<condition>.*$)");
            RegisterName = match.Groups["register"].ToString();
            IncDec = match.Groups["incdec"].ToString() == "inc";
            Increment = int.Parse(match.Groups["increment"].ToString());
            Condition = new Condition(match.Groups["condition"].ToString());
        }
    }
}
