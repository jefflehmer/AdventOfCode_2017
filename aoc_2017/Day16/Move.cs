using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc_2017.Day16
{
    public class Move
    {
        public enum DanceStyle
        {
            Spin = 0,
            Xchange,
            Partner
        }

        private string _step;
        public DanceStyle Style { get; set; }
        public object Index1 { get; set; }
        public object Index2 { get; set; }

        public Move(string step)
        {
            this._step = step;
            Parse();
        }

        // i'm sure there's a more elegant and clever way of parsing the input but this is a race to get done
        private void Parse()
        {
            // ex's: s1,x3/4,pe/b
            //       x11/4,pd/h,x10/5,s3,x0/7,pp/n,..
            var moves = _step.Substring(1, _step.Length - 1);
            switch (_step.First())
            {
                case 's':
                    Style = DanceStyle.Spin;
                    Index1 = int.Parse(moves);
                    Index2 = -1;
                    break;
                case 'x':
                    Style = DanceStyle.Xchange;
                    var indices= moves.Split('/');
                    Index1 = int.Parse(indices[0]);
                    Index2 = int.Parse(indices[1]);
                    break;
                case 'p':
                    // Index1/2 are "objects" but should be int's and do index conversion here?
                    Style = DanceStyle.Partner;
                    var partners= moves.Split('/');
                    Index1 = partners[0].ToCharArray()[0];
                    Index2 = partners[1].ToCharArray()[0];
                    break;
            }
        }
    }
}