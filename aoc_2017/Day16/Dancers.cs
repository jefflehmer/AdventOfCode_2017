using System;
using System.Threading;

namespace aoc_2017.Day16
{
    internal class Dancers
    {
        private string ChorusLine = "abcdefghijklmnop";

        public Dancers()
        {
            // initialize the chorus line (a..p)
        }

        internal void Step(Move movement)
        {
            switch (movement.Style)
            {
                case Move.DanceStyle.Spin:
                    Spin(movement.Partner1);
                    break;
                case Move.DanceStyle.Xchange:
                case Move.DanceStyle.Partner: // these two are essentially the same action
                    Exchange(movement.Partner1, movement.Partner2);
                    break;
            }
        }

        // what's the best way to do this? 
        //      1. use an index rather than actually move the characters?
        private void Spin(int partner1)
        {
            ;
        }

        private void Exchange(int partner1, int partner2)
        {
            ;
        }
    }
}