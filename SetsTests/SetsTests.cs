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
			List<int> sortedExp = new List<int>();
			foreach (int i in exp)
			{
				sortedExp.Add(i);
			}
			sortedExp.Sort();

			return sortedExp.SequenceEqual(res);
		}

		[TestMethod()]
		public void GetUnion_Sizes_3_And_2()
		{
			List<int> setA = new List<int> { 1, 7, 3 };
			List<int> setB = new List<int> { 2, 5 };
			List<int> exp = new List<int> { 2, 1, 3, 7, 5 };

			List<int> res = Sets.GetUnion(setA, setB);

			Assert.IsTrue( ResIsValid(res, exp) );
		}

		[TestMethod()]
		public void GetUnion_Test_Duplicates()
		{
			List<int> setA = new List<int> { 3, 3 };
			List<int> setB = new List<int> { 3 };
			List<int> exp = new List<int> { 3 };

			List<int> res = Sets.GetUnion(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void ResIsValid_Test_Equal_Sorted_Sets()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 1, 2, 3 };

			Assert.IsTrue( ResIsValid(setA, setB) );
		}

		[TestMethod()]
		public void ResIsValid_Test_Equal_Unsorted_Sets()
		{
			List<int> exp = new List<int> { 1, 2, 3 };
			List<int> res = new List<int> { 3, 2, 1 };

			Assert.IsTrue(ResIsValid(exp, res));
		}


		[TestMethod()]
		public void ResIsValid_Test_Not_Equal_Sets()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 1, 2 };

			Assert.IsFalse(ResIsValid(setA, setB));
		}

		[TestMethod()]
		public void ResIsValid_Test_Equal_Sets_Not_Sorted()
		{
			List<int> res = new List<int> { 3, 2, 1 };
			List<int> exp = new List<int> { 1, 2, 3 };

			Assert.IsFalse(ResIsValid(res, exp));
		}

	}
}
