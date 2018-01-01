using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day21
{
    class Rule
    {
        public string Match { get; set; }
        public string Conversion { get; set; }

        internal static Rule Parse(string raw)
        {
            var regex = Regex.Match(raw, @"(?<match>.+) => (?<conversion>.+)$");
            var match = regex.Groups["match"].ToString();
            var conversion = regex.Groups["conversion"].ToString();

            return new Rule { Match = match, Conversion = conversion };
        }
    }
}
