using Newtonsoft.Json.Linq;
using System;

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

		    var inputProducts = (JObject)v2["products"];
            dynamic outputProducts = new JArray();

		    foreach (var x in inputProducts)
		    {
                dynamic product = new JObject();
		        product = x.Value;
                product.id = x.Key;
                outputProducts.Add(product);
            }
		    v3.products = outputProducts;
			Console.Write(v3);
		}
	}
}
