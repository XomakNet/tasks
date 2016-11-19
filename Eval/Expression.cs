using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalTask
{
    class Expression
    {
        Expression left, right;
        char op;

        public Expression(char oper, Expression result, Expression right2)
        {
            op = oper;
            left = result;
            right = right2;
        }
    }
}
