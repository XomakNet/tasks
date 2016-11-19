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
		    string json = Console.In.ReadToEnd();
            
            string output = DoThings(json, input);

			Console.WriteLine(output);
		}

        private static string DoThings(string json, string input)
	    {
            var replaced = JsonReplacer.Replace(json, input);
            return new Calculator(replaced).Calc().ToString();
        }

	    [TestFixture]
	    public class EvalProgram_Should
	    {
	        [Test]
	        public void DoSomething_WhenSomething()
	        {
                string json = "{x:1,xx:2.2,yy:3,y:5}";
                string expr = "x+xx+yy+y";
                Assert.AreEqual("11,2", DoThings(json, expr));
            }
	    }
	}
}
