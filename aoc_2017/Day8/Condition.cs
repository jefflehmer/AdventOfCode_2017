using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day8
{
    public class Condition
    {
        public string Raw { get; set; }
        public string Left { get; set; }
        public string Operation { get; set; }
        public string Right { get; set; }

        public Condition(string raw)
        {
            Raw = raw;
            Parse();
        }

        private void Parse()
        {
            //string sample = @"xzn < 9";
            var match = Regex.Match(Raw, @"(?<left>.*) (?<operation>.*) (?<right>.*$)");
            Left = match.Groups["left"].ToString();
            Operation = match.Groups["operation"].ToString();
            Right = match.Groups["right"].ToString();
        }
    }
}
