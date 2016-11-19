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

        public double Calc(string str)
        {
            //return calcTerm();
            return 0;
        }

        private Expression calcTerm()
        {
            var ex = calcFactor();

        }

        private Expression calcFactor()
        {
            var ex = parsePrimary();

        }

        private Expression parsePrimary()
        {
            Expression result = null;

            if (isDigit(currentChar()))
            {
                result = parseInteger();
            }
            else if (currentChar() == '(')
            {
                nextChar();
                result = parse();
                skipNextChar();
            }
            else
            {
                System.out.println("Error: unexpected symbol " + currentChar() + " at " + cursor);
            }

            return result;
        }
    }
}
