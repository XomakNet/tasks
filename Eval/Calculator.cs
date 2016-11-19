﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EvalTask
{
    public class Calculator
    {
        private string input;
        private int cursor;


        public Calculator(string str)
        {
            input = str;
            cursor = 0;
        }

        public double Calc()
        {
            //return calcTerm();
            return 0;
        }

        [Test]
        public void CheckIfCalcReturnEqualNumber()
        {
            var calc = new Calculator("2");
            Assert.AreEqual(2, calc.Calc());
        }

        [Test]
        public void SimpleAddOperationIsCorrect()
        {
            var calc = new Calculator("20+3");
            Assert.AreEqual(23, calc.Calc());
        }

        private Expression calcTerm()
        {
            var ex = calcFactor();
            return ex;
        }

        private Expression calcFactor()
        {
            var ex = parsePrimary();
            return ex;
        }

        private Expression parsePrimary()
        {
            Expression result = null;

            if (IsDigit(CurrentChar()))
            {
                result = parseInteger();
            }
            else if (CurrentChar() == '(')
            {
                NextChar();
                result = Calc();
                skipNextChar();
            }
            else
            {
                Console.WriteLine("Error: unexpected symbol " + CurrentChar() + " at " + cursor);
            }

            return result;
        }

        private bool IsDigit(char currentChar)
        {
            double d;
            return double.TryParse("" + currentChar, out d);
        }

        private char NextChar()
        {
            if (cursor + 1 < input.Length)
            {
                cursor++;
            }
            else
            {
                return '\n';
            }

            return CurrentChar();
        }

        private char CurrentChar()
        {
            return input[cursor];
        }
    }
}
