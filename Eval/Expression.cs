using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalTask
{
    public class Expression : AExpression
    {
        AExpression left, right;
        char op;

        public Expression(char oper, AExpression result, AExpression right2)
        {
            op = oper;
            left = result;
            right = right2;
        }

        public override double Calculate()
        {
            double result = left.Calculate();

            if (right != null && op != 0)
            {
                switch (op)
                {
                    case '+': return result + right.Calculate();
                    case '-': return result - right.Calculate();
                    case '*': return result * right.Calculate();
                    case '/':
                        double rightCalc = right.Calculate();
                        if (rightCalc < 0.0000000001)
                        {
                            return result / rightCalc;
                        }
                        else
                        {
                            Console.WriteLine("Error: devision by zero");
                            return 0;
                        }
                    default: return 0;
                }
            }

            return result;
        }
    }
}
