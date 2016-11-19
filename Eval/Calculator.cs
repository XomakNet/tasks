using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var ex = CalcAll();
            return 0;
        }

        private Expression CalcAll()
        {
            return calcTerm();
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

        private Expression ParseInteger()
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
