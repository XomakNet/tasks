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
            return new Expression();
            
        }
    }
}
