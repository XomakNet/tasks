using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SimQLTask
{
	[TestFixture]
	public class SimQLProgram_Should
	{
		[Test]
		public void SimSQLShould()
		{
			var results = SimQLProgram.ExecuteQueries(
				"{" +
				"'data': {'a':{'x':3.14}}, " +
				"'queries': ['a.x', 'b.c']" +
				"}");

			Assert.AreEqual(new String[] {"a.x = 3.14", "b.c"}, results.ToArray());
		}

        [Test]
		public void SumEmptyDataToZero()
		{
			var results = SimQLProgram.ExecuteQueries(
				"{" +
				"'data': [], " +
				"'queries': ['sum(item.cost)', 'sum(itemsCount)']}");
			Assert.AreEqual(new[] {0, 0}, results);
		}

		[Test]
		public void SumSingleItem()
		{
			var results = SimQLProgram.ExecuteQueries(
				"{" +
				"'data': [{'itemsCount':42}, {'foo':'bar'}], " +
				"'queries': ['sum(itemsCount)']}");
			Assert.AreEqual(new[] { 42 }, results);
		}
	}
}