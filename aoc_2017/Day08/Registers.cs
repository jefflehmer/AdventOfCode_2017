using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day08
{
    public class Registers
    {
        private Dictionary<string, Register> _bank = null;
        public Dictionary<string, Register> Bank => _bank ?? (_bank = new Dictionary<string, Register>());

        public int ApplyInstruction(Instruction inst)
        {
            // update the actee accordingly if the condition passes
            if (TestCondition(inst))
                return UpdateRegisterValue(inst);

            return 0;
        }

        private bool TestCondition(Instruction inst)
        {
            // retrieve the register being tested
            var testee = Bank[inst.Condition.Left];
            var right = int.Parse(inst.Condition.Right);

            switch (inst.Condition.Operation)
            {
                case "<": return testee.Value < right;
                case ">": return testee.Value > right;
                case "<=": return testee.Value <= right;
                case ">=": return testee.Value >= right;
                case "==": return testee.Value == right;
                case "!=": return testee.Value != right;
            }

            return false;
        }

        private int UpdateRegisterValue(Instruction inst)
        {
            // retrieve the register being acted upon
            var actee = Bank[inst.RegisterName];
            if (inst.IncDec)
                actee.Value += inst.Increment;
            else
                actee.Value -= inst.Increment;

            return actee.Value;
        }

        public Register FindLargest()
        {
            Register largest = Bank.First().Value;
            foreach (var register in Bank)
            {
                if (register.Value.Value > largest.Value)
                    largest = register.Value;
            }

            return largest;
        }
    }
}
