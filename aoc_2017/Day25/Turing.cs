using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day25
{
    class Turing
    {
        private Dictionary<string, State> States;

        private const int NumLinesPerState = 10;

        public Turing(string[] raw)
        {
            States = new Dictionary<string, State>(raw.Length);

            for (var i = 2; i < raw.Length; i += NumLinesPerState) // a new state is defined every 10 lines starting at line 2
            {
                var regex = Regex.Match(raw[i+1], @"In state (?<stateName>.+):$");
                var stateName = regex.Groups["stateName"].ToString();
                var rawBlueprint = raw.SubArray(i+2, 8);
                States.Add(stateName, State.Parse(rawBlueprint));
            }
        }
    }
}
