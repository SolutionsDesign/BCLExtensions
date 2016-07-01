using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using SD.Tools.BCLExtensions.CollectionsRelated;

namespace Tests
{
	[TestFixture]
    public class DictionaryExtensionTests
    {
		[Test]
		public void AddRangeTest()
		{
			var toAdd = new List<int> {1, 2, 3, 4, 5};
			var toAddTo = new Dictionary<string, int>();
			Assert.AreEqual(0, toAddTo.Count);
			toAddTo.AddRange(i=>i.ToString(), toAdd);
			Assert.IsTrue(toAddTo.Any());
			Assert.AreEqual(toAdd.Count, toAddTo.Count);
			foreach(var kvp in toAddTo)
			{
				Assert.AreEqual(kvp.Key, kvp.Value.ToString());
				Assert.IsTrue(toAdd.Contains(kvp.Value));
			}
		}
    }
}
