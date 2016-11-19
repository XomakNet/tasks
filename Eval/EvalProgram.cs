using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace EvalTask
{
	class EvalProgram
	{
		static void Main(string[] args)
		{
		    string input = Console.In.ReadLine();
		    string json = Console.In.ReadLine();//ReadToEnd();
            string output = new Calculator(JsonGovno.Replace(json,input)).Calc().ToString();
			Console.WriteLine(output);
		}

	}
}
