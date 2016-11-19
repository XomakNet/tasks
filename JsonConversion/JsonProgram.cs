using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using EvalTask;
using static EvalTask.EvalProgram;

namespace JsonConversion
{
    class JsonProgram
    {
        static void Main()
        {
            string json = Console.In.ReadToEnd();
            //string json = Console.In.ReadLine();
            JObject v2 = JObject.Parse(json);
            dynamic v3 = new JObject();
            v3.version = "3";

            var inputProducts = (JObject) v2["products"];
            var inputConstants = (JObject) v2["constants"];
            dynamic outputProducts = new JArray();
            dynamic outputConstants = new JObject();

            if (inputConstants != null)
            {
                foreach (var constant in inputConstants)
                {
                    outputConstants[constant.Key] = constant.Value;
                }

                //v3["constants"] = outputConstants;
            }

            foreach (var x in inputProducts)
            {
                dynamic product = new JObject();
                dynamic oldProduct = x.Value;
                product.id = int.Parse(x.Key);
                product.name = oldProduct.name;
                if (oldProduct.price.Value is string)
                {
                    var result = EvalProgram.DoThings(outputConstants.ToString(), oldProduct.price.Value);
                    try
                    {
                        product.price = Convert.ToDouble(result, CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        
                        throw new Exception(result);
                    }
                    
                }
                else
                {
                    product.price = oldProduct.price;
                }
                product.count = oldProduct.count;
                outputProducts.Add(product);
            }
            v3.products = outputProducts;
            v3 = MakeSingleQuotes(new string[] {"name", "price", "count"}, v3.ToString());
            Console.Write(v3);
        }

        public static String MakeSingleQuotes(String[] properties, String text)
        {
            // string pattern = "\"(test)\": (\"([^\"]*)\"|[^,}]+)";
            string quottedPattern = "\"({0})\": (\"([^\"]*)\")";
            string pattern = "\"({0})\": ([^,}}])";
            foreach (var param in properties)
            {
                text = Regex.Replace(text, String.Format(quottedPattern, param), "'$1': '$3'");
                text = Regex.Replace(text, String.Format(pattern, param), "'$1': $2");
            }
            return text;
        }
    }
}