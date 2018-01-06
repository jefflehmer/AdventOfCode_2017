using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day23
{
    class Tablet
    {
        private const long DefaultReturnValue = 1;

        public Dictionary<string, long> Registers { get; set; }
        public long LastFrequency = -1;
        public long MulCount { get; set; }

        public Tablet()
        {
            Registers = new Dictionary<string, long>();
            MulCount = 0;
        }
        public Tablet(string seedRegister, int seedValue): this()
        {
            Registers.Add(seedRegister, seedValue);
        }
        public long Invoke(string rawInstruction)
        {
            var match = Regex.Match(rawInstruction, @"(?<instruction>.*) (?<register1>.*) (?<register2>.*$)");
            if (string.IsNullOrEmpty(match.Groups["register2"].ToString())) // quick hack to deal with cases where there is only one register
                match = Regex.Match(rawInstruction, @"(?<instruction>.*) (?<register1>.*$)");
            var instruction = match.Groups["instruction"].ToString();
            var register1 = match.Groups["register1"].ToString();
            var register2 = match.Groups["register2"].ToString();

            switch (instruction)
            {
                case "set":
                    return doSet(register1, register2);

                case "sub":
                    return doSub(register1, register2);

                case "mul":
                    return doMul(register1, register2);

                case "jnz":
                    return doJnz(register1, register2);

                default:
                    throw new ArgumentNullException("Invalid instruction received!");
            }
        }

        private long doSet(string register1, string register2)
        {
            var value = GetRegisterOrValue(register2);
            Registers[register1] = value;
            return DefaultReturnValue;
        }

        private long doSub(string register1, string register2)
        {
            Registers[register1] -= GetRegisterOrValue(register2);
            return DefaultReturnValue;
        }

        private long doMul(string register1, string register2)
        {
            MulCount++;
            if (!Registers.ContainsKey(register1))
                Registers.Add(register1, 0L);
            Registers[register1] *= GetRegisterOrValue(register2);
            return DefaultReturnValue;
        }

        private long doJnz(string register1, string register2)
        {
            var value1 = GetRegisterOrValue(register1);
            var value2 = GetRegisterOrValue(register2);
            return value1 != 0 ? value2 : DefaultReturnValue;
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
