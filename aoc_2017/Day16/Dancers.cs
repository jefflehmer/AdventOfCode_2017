using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace aoc_2017.Day16
{
    internal class Dancers
    {
        private string OriginalLineUp = "abcdefghijklmnop";
        private char[] ChorusLine = null;

        public string CurrentLineUp
        {
            get
            {
                var line = new StringBuilder();
                for (var i = 0; i < ChorusLine.Length; i++)
                    line.Append(ChorusLine[Idx(i)]);
                return line.ToString();
            }
        }

        private int FirstDancer { get; set; }

        public Dancers()
        {
            // initialize the chorus line (a..p)
            ChorusLine = OriginalLineUp.ToCharArray();
            FirstDancer = 0;
        }

        internal void Step(Move movement)
        {
            switch (movement.Style)
            {
                case Move.DanceStyle.Spin:
                    Spin((int)movement.Index1);
                    break;
                case Move.DanceStyle.Xchange:
                    Exchange((int)movement.Index1, (int)movement.Index2);
                    break;
                case Move.DanceStyle.Partner:
                    movement.Index1 = ConvertPartnerToIndex((char)movement.Index1);
                    movement.Index2 = ConvertPartnerToIndex((char)movement.Index2);
                    Exchange((int)movement.Index1, (int)movement.Index2);
                    break;
            }
        }

        private int ConvertPartnerToIndex(char partner)
        {
            var lineup = CurrentLineUp;
            for (var i = 0; i < ChorusLine.Length; i++)
            {
                if (lineup[i] == partner)
                    return i;
            }
            return -1;
        }

        // what's the best way to do this? 
        //      1. use an index rather than actually move the characters?
        private void Spin(int partner1)
        {
            FirstDancer = Idx(ChorusLine.Length - partner1);
        }

        private void Exchange(int index1, int index2)
        {
            char temp = ChorusLine[Idx(index1)];
            ChorusLine[Idx(index1)] = ChorusLine[Idx(index2)];
            ChorusLine[Idx(index2)] = temp;
        }

        // since the Chorus Line does not truly "spin" we need to offset the index
        private int Idx(int partner)
        {
            return (FirstDancer + partner) % OriginalLineUp.Length;
        }
    }
}