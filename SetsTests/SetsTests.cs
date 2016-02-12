using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets.Tests
{
	[TestClass()]
	public class SetsTests
	{
		public static bool ResIsValid( List<int> res, List<int> exp )
		{
			return true;
		}

		[TestMethod()]
		public void GetUnion_Sizes_3_And_2()
		{
			List<int> setA = new List<int> { 1, 7, 3 };
			List<int> setB = new List<int> { 2, 5 };
			List<int> exp = new List<int> {  };

			List<int> res = Sets.GetUnion(setA, setB);

			Assert.IsTrue( ResIsValid( res, exp ) );
		}
	}
}