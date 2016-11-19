using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
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

            string output;
            try
            {
                output = DoThings(json, input);
            }
            catch (Exception e)
            {
                output = e.Message;
            }

            Console.WriteLine(output);
        }

        private static string DoThings(string json, string input)
        {
            var replaced = JsonReplacer.Replace(json, input);
            return new Calculator(replaced).Calc().ToString(CultureInfo.InvariantCulture);
        }

        [TestFixture]
        public class EvalProgram_Should
        {
            [Test]
            public void WorkOnNullJson()
            {
                string json = null;
                string expr = "1+2-2+1";
                Assert.AreEqual("2", DoThings(json, expr));
            }

            [Test]
            public void WorkWithEmptyJson()
            {
                string json = "{}";
                string expr = "1+2-2+1";
                Assert.AreEqual("2", DoThings(json, expr));
            }


            [Test]
            public void WorkWithJson()
            {
                string json = "{x:1,xx:2,yy:3,y:5}";
                string expr = "x+xx+yy+y";
                Assert.AreEqual("11", DoThings(json, expr));
            }
        }
    }
}