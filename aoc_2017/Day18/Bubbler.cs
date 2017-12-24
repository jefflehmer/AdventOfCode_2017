using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day18
{
    class Bubbler
    {
        private const long DefaultInstructionJump = 1;

        public Dictionary<string, long> Registers { get; set; }
        public Bubbler Partner { get; set; }
        public long SendCount { get; set; }
        private BlockingCollection<long> Queue { get; set; }

        public Bubbler()
        {
            Registers = new Dictionary<string, long>();
            Queue = new BlockingCollection<long>();
            SendCount = 0L;
        }

        public long Process(string[] instructions)
        {
            var idx = 0L;
            do
            {
                idx += Invoke(instructions[idx]);
            } while (idx >= 0 && idx < instructions.Length);

            return SendCount;
        }
        protected long Invoke(string rawInstruction)
        {
            var match = Regex.Match(rawInstruction, @"(?<instruction>.*) (?<register1>.*) (?<register2>.*$)");
            if (string.IsNullOrEmpty(match.Groups["register2"].ToString())) // quick hack to deal with cases where there is only one register
                match = Regex.Match(rawInstruction, @"(?<instruction>.*) (?<register1>.*$)");
            var instruction = match.Groups["instruction"].ToString();
            var register1 = match.Groups["register1"].ToString();
            var register2 = match.Groups["register2"].ToString();

            switch (instruction)
            {
                case "snd":
                    return doSend(register1);

                case "set":
                    return doSet(register1, register2);

                case "add":
                    return doAdd(register1, register2);

                case "mul":
                    return doMul(register1, register2);

                case "mod":
                    return doMod(register1, register2);

                case "rcv":
                    return doReceive(register1);

                case "jgz":
                    return doJgz(register1, register2);

                default:
                    throw new ArgumentNullException("Invalid instruction received!");
            }
        }

        private long doSend(string register)
        {
            Partner.Queue.Add(GetRegisterOrValue(register));
            SendCount++;
            return DefaultInstructionJump;
        }

        private long doSet(string register1, string register2)
        {
            long value = GetRegisterOrValue(register2);
            Registers[register1] = value;
            return DefaultInstructionJump;
        }

        private long doAdd(string register1, string register2)
        {
            Registers[register1] += GetRegisterOrValue(register2);
            return DefaultInstructionJump;
        }

        private long doMul(string register1, string register2)
        {
            if (!Registers.ContainsKey(register1))
                Registers.Add(register1, 0L);
            Registers[register1] *= GetRegisterOrValue(register2);
            return DefaultInstructionJump;
        }

        private long doMod(string register1, string register2)
        {
            Registers[register1] %= GetRegisterOrValue(register2);
            return DefaultInstructionJump;
        }

        private long doReceive(string register)
        {
            var peek = 0L;
            if (Queue.TryTake(out peek, 100))
                Registers[register] = peek;
            else
                Partner.Queue.CompleteAdding();

            return DefaultInstructionJump;
        }

        private long doJgz(string register1, string register2)
        {
            var value1 = GetRegisterOrValue(register1);
            var value2 = GetRegisterOrValue(register2);
            return value1 > 0 ? value2 : DefaultInstructionJump;
        }


        private long GetRegisterOrValue(string register)
        {
            var value = 0L;
            if (!long.TryParse(register, out value)) // test for number or register name
            {
                if (!Registers.ContainsKey(register))
                    Registers.Add(register, 0);
                value = Registers[register];
            }

            return value;
        }
    }
}
