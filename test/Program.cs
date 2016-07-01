using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SD.Tools.BCLExtensions;

namespace Tester
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }

	[TestFixture]
	public class DictionaryTests
	{
		[Test]
		public void AddRangeTest()
		{
			var toAdd = new List<int> {1, 2, 3, 4, 5};
			var toAddTo = new Dictionary<string, int>();
			toAddTo.AddRange
		}
	}

}
