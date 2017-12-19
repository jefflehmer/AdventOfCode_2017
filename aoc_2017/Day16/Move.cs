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
        public int Partner1 { get; set; }
        public int Partner2 { get; set; }

        public Move(string step)
        {
            this._step = step;
            Parse();
        }

        // i'm sure there's a more elegant way of parsing the input but this is a race to get done
        private void Parse()
        {
            // ex's: s1,x3/4,pe/b
            switch (_step.First())
            {
                case 's':
                    Style = DanceStyle.Spin;
                    Partner1 = int.Parse(_step[1].ToString());
                    Partner2 = -1;
                    break;
                case 'x':
                    Style = DanceStyle.Xchange;
                    Partner1 = int.Parse(_step[1].ToString());
                    Partner2 = int.Parse(_step[3].ToString());
                    break;
                case 'p':
                    Style = DanceStyle.Partner;
                    Partner1 = _step[1]-'a';
                    Partner2 = _step[3]-'a';
                    break;
            }
        }
    }
}