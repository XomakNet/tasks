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
                dynamic oldProduct = x.Value;
                product.id = int.Parse(x.Key);
                product.name = oldProduct.name;
		        product.price = oldProduct.price;
		        product.count = oldProduct.count;
                outputProducts.Add(product);
            }
		    v3.products = outputProducts;
			Console.Write(v3);
		}
	}
}
