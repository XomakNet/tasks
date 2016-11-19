using System;

namespace EvalTask
{
	class EvalProgram
	{
		static void Main(string[] args)
		{
		    string input = Console.In.ReadLine();//ReadToEnd(); // 
            string output = new Calculator(input).Calc().ToString();
			Console.WriteLine(output);
		}

	}
}
