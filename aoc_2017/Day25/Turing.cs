using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day25
{
    // I know this is probably not the best use of IEnumerator
    // but I am programming this for fun and it's Christmas Day.
    // Besides, it does a great job of hiding implementation details!
    class Turing : IEnumerator<int>
    {
        #region props, fields, consts, and ctors
        private Dictionary<string, State> States;
        private HashSet<int> Tape;
        public int Checksum => Tape.Count;

        private const int NumLinesPerState = 10;

        public Turing(string startState, string[] raw)
        {
            InitializeStates(raw);
            InitializeTape(startState); // must come after init-states
        }

        private void InitializeStates(string[] raw)
        {
            States = new Dictionary<string, State>(raw.Length);

            for (var i = 2; i < raw.Length; i += NumLinesPerState) // a new state is defined every 10 lines starting at line 2
            {
                var regex = Regex.Match(raw[i + 1], @"In state (?<stateName>.+):$");
                var stateName = regex.Groups["stateName"].ToString();
                var rawBlueprint = raw.SubArray(i + 2, 8);
                States.Add(stateName, State.Parse(rawBlueprint));
            }
        }

        private void InitializeTape(string startState)
        {
            Tape = new HashSet<int>();
            _index = 0;
            CurrentState = States[startState];
        }
        #endregion props, fields, consts, and ctors

        #region IEnumerator<int>

        private int _index;
        private State CurrentState { get; set; }
        public int Current => Tape.Contains(_index) ? 1 : 0; // IEnumerator forces this to be an int instead of a bool
        private bool CurrentTest => Current == 1;

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool MoveNext()
        {
            // I could have used linq to put this whole method into one line but that would have been unreadable
            var mover = CurrentTest ? CurrentState.One : CurrentState.Zero;

            if (mover.WriteValue == 1)
            {
                if (!CurrentTest)
                    Tape.Add(_index);
            }
            else
            {
                if (CurrentTest)
                    Tape.Remove(_index);
            }

            _index += mover.MoveDirection == State.MoveWrite.TapeDirection.left ? -1 : 1;

            CurrentState = States[mover.NextState];

            return true;
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Dispose()
        {
            ;
        }
        #endregion IEnumerator<int>
    }
}
