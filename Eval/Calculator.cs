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
            return ex.Calculate();
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
    }
}
