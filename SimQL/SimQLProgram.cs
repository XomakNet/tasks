using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.String;

namespace SimQLTask
{
	class SimQLProgram
	{
		static void Main(string[] args)
		{
			var json = Console.In.ReadToEnd();
			foreach (var result in ExecuteQueries(json))
				Console.WriteLine(result);
		}

		public static IEnumerable<string> ExecuteQueries(string json)
		{
            var queriesResults = new List<String>();

		    var jObject = JObject.Parse(json);
		    var queries = ((JArray) jObject["queries"]).Select(v => v.Value<String>());
		    var data = (JObject) jObject["data"];


		    foreach (var queryParams in queries.Select(q => q.Split('.')))
		    {
		        var tempResult = data;
		        string valueResult = "";
		        JToken currValue;

		        foreach (var queryParam in queryParams)
		        {

                    if (queryParam == "data")
		            {
		                continue;
		            }

		            if (tempResult.TryGetValue(queryParam, out currValue))
		            {
		                if (currValue != null)
		                {

		                    try
		                    {
		                        tempResult = (JObject) currValue;
		                    }
		                    catch
		                    {
		                        valueResult = currValue.Value<string>();
		                    }

		                }
		                else
		                {
                            valueResult = "";
                            break;
                        }
		            }
		            else
		            {
		                valueResult = "";
		                break;
		            }

		        }

		        var queryResultStr = Join(".", queryParams) + (valueResult.Equals("") ? "" : " = " + valueResult);

                queriesResults.Add(queryResultStr);
		    }

            return queriesResults;
		}
	}
}
