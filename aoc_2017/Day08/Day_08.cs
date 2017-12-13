using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day08
{
    public class Day_08
    {
        public static void Do(string srcFile)
        {
            var registers = new Registers();

            var lines = System.IO.File.ReadAllLines(srcFile);
            var instructions = lines.Select(line => new Instruction(line)).ToList();

            // first create the bank of registers
            foreach (var instr1 in instructions)
            {
                if (!registers.Bank.ContainsKey(instr1.RegisterName))
                    registers.Bank.Add(instr1.RegisterName, new Register() {Name=instr1.RegisterName, Value = 0});
            }

            // then loop through and execute all of the instructions
            var highest = 0;
            foreach (var instruction2 in instructions)
            {
                var local = registers.ApplyInstruction(instruction2);
                if (local > highest) highest = local;
            }

            var largest = registers.FindLargest();

            Console.Write($"Day 08: Largest Final Value: {largest.Value}  Highest Value: {highest}");
            Console.ReadLine();
        }
    }
}
