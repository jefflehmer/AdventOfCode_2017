using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day25
{
    public class State
    {
        #region props, fields, consts, and ctors
        public MoveWrite Zero { get; set; }
        public MoveWrite One { get; set; }

        private State(MoveWrite zeroVal, MoveWrite oneVal)
        {
            Zero = zeroVal;
            One = oneVal;
        }
        public static State Parse(string[] blueprint)
        {
            if (blueprint[0].Trim() != "If the current value is 0:")
                throw new Exception("Invalid definition for value 0.");
            var regex = Regex.Match(blueprint[1].Trim(), @"- Write the value (?<zeroSet>.+).$");
            var zeroSet = int.Parse(regex.Groups["zeroSet"].ToString());
            regex = Regex.Match(blueprint[2].Trim(), @"- Move one slot to the (?<zeroDir>.+).$");
            var zeroDir = (MoveWrite.TapeDirection)Enum.Parse(typeof(MoveWrite.TapeDirection), regex.Groups["zeroDir"].ToString());
            regex = Regex.Match(blueprint[3].Trim(), @"- Continue with state (?<zeroNext>.+).$");
            var zeroNext = regex.Groups["zeroNext"].ToString();
            var zero = new MoveWrite(zeroSet, zeroDir, zeroNext);


            if (blueprint[4].Trim() != "If the current value is 1:")
                throw new Exception("Invalid definition for value 1.");
            regex = Regex.Match(blueprint[5].Trim(), @"- Write the value (?<oneSet>.+).$");
            var oneSet = int.Parse(regex.Groups["oneSet"].ToString());
            regex = Regex.Match(blueprint[6].Trim(), @"- Move one slot to the (?<oneDir>.+).$");
            var oneDir = (MoveWrite.TapeDirection)Enum.Parse(typeof(MoveWrite.TapeDirection), regex.Groups["oneDir"].ToString());
            regex = Regex.Match(blueprint[7].Trim(), @"- Continue with state (?<oneNext>.+).$");
            var oneNext = regex.Groups["oneNext"].ToString();
            var one = new MoveWrite(oneSet, oneDir, oneNext);

            return new State(zero, one);
        }
        #endregion props, fields, consts, and ctors

        public class MoveWrite
        {
            public enum TapeDirection
            {
                left = 0,
                right
            }

            public MoveWrite(int write, TapeDirection move, string next)
            {
                WriteValue = write;
                MoveDirection = move;
                NextState = next;
            }
            public int WriteValue { get; set; }
            public TapeDirection MoveDirection { get; set; }
            public string NextState { get; set; }
        }
    }
}
