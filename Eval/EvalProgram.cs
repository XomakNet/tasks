using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace EvalTask
{
	class EvalProgram
	{
		static void Main(string[] args)
		{
		    string input = Console.In.ReadLine();
		    string json = Console.In.ReadLine();//ReadToEnd();
		    var kek = JsonGovno.Replace(json, input);
            string output = new Calculator(JsonGovno.Replace(json,input)).Calc().ToString();
			Console.WriteLine(output);
		}

	    [TestFixture]
	    public class EvalProgram_Should
	    {
	        [Test]
	        public void DoSomething_WhenSomething()
	        {

	        }
	    }
	}
}
