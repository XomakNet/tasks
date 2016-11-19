﻿using System;
using System.Collections.Generic;
 using System.IO;
 using System.Linq;
using System.Text;
 using System.Text.RegularExpressions;
 using System.Threading.Tasks;
 using DynamicExpresso;
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
            //var ex = CalcAll();
            return Eval(input);
        }

        static double Eval(String expression)
        {
            var interpreter = new Interpreter();
            var kek = interpreter.Eval(expression);
            var result = Convert.ToDouble(kek);
            if (double.IsInfinity(result))
                throw new DivideByZeroException();
            return result;
        }

        private AExpression CalcAll()
        {
            return CalcTerm();
        }

        private AExpression CalcTerm()
        {
            var result = CalcFactor();

            while (CurrentChar() == '+' || CurrentChar() == '-')
            {
                char curChar = CurrentChar();
                NextChar();
                AExpression right = CalcFactor();
                result = new Expression(curChar, result, right);
            }

            return result;
        }

        private AExpression CalcFactor()
        {
            var result = ParsePrimary();

            while (CurrentChar() == '/' || CurrentChar() == '*')
            {
                char curChar = CurrentChar();
                NextChar();
                AExpression right = ParsePrimary();
                result = new Expression(curChar, result, right);
            }

            return result;
        }

        private AExpression ParsePrimary()
        {
            AExpression result = null;

            if (IsDigit(CurrentChar()))
            {
                result = ParseInteger();
            }
            else if (CurrentChar() == '(')
            {
                NextChar();
                result = CalcAll();
                SkipNextChar();
            }
            else
            {
                Console.WriteLine("Error: unexpected symbol " + CurrentChar() + " at " + cursor);
            }

            return result;
        }

        private void SkipNextChar()
        {
            if (cursor + 1 < input.Length)
            {
                cursor++;
            }
        
        }

        private Primary ParseInteger()
        {
            String number = "";

            do
            {
                number += CurrentChar();
            } while (IsDigit(NextChar()));

            return new Integer2(number);
        }

        private bool IsDigit(char currentChar)
        {
            double d;
            return double.TryParse("" + currentChar, out d) || currentChar.Equals('.') || currentChar.Equals(',');
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


        [TestFixture]
        public class Calculator_Should
        {
            [Test]
            public void CheckIfCalcReturnEqualNumber()
            {
                var calc = new Calculator("2");
                Assert.AreEqual(2, calc.Calc());
            }

            [Test]
            public void CheckIfCalcReturnEqualDoubleNumber()
            {
                var calc = new Calculator("1.234");
                Assert.AreEqual(1.234, calc.Calc(), 0.000001);
            }

            [Test]
            public void SimpleAddOperationIsCorrect()
            {
                var calc = new Calculator("20+3");
                Assert.AreEqual(23, calc.Calc(), 0.000001);
            }

            [Test]
            public void SimpleEqualMultiplicationIsCorrect()
            {
                var calc = new Calculator("7*11");
                Assert.AreEqual(77, calc.Calc(), 0.000001);
            }

            [Test]
            public void NumberInBracesEqualToCalculated()
            {
                var calc = new Calculator("(2.12)");
                Assert.AreEqual(2.12, calc.Calc(), 0.000001);
            }
            
            [Test]
            public void OperationsPriorityIsCorrect()
            {
                var calc = new Calculator("2+3*2");
                Assert.AreEqual(8, calc.Calc(), 0.000001);
            }

            [Test]
            public void DivisionByOne()
            {
                var calc = new Calculator("1/1");
                Assert.AreEqual(1, calc.Calc(), 0.000001);
            }

            [Test]
            public void NegativeNumberAdd()
            {
                var calc = new Calculator("-5+6");
                Assert.AreEqual(1, calc.Calc(), 0.000001);
            }

            [Test]
            public void NegativNumberSub()
            {
                var calc = new Calculator("-38-4");
                Assert.AreEqual(-42, calc.Calc(), 0.000001);
            }

            [Test]
            public void ReverseReverseSignIfMinus()
            {
                var calc = new Calculator("-(-38-4)");
                Assert.AreEqual(42, calc.Calc(), 0.000001);
            }
        }
    }
}

