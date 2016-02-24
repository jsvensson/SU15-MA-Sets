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
			List<int> setA = new List<int> { 3, 3, 3, 3 };
			List<int> setB = new List<int> { 3, 3, 3 };
			List<int> exp = new List<int> { 3 };

			List<int> res = Sets.GetUnion(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		// Testa GetIntersection()

		[TestMethod()]
		public void GetIntersection_Has_Intersection_No_Duplicate()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 3, 4, 5 };

			List<int> exp = new List<int>() { 3 };
			List<int> res = Sets.GetIntersection(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetIntersection_Has_Intersection_With_Duplicate()
		{
			List<int> setA = new List<int> { 1, 2, 3, 3 };
			List<int> setB = new List<int> { 3, 3, 4, 5 };

			List<int> exp = new List<int>() { 3 };
			List<int> res = Sets.GetIntersection(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetIntersection_No_Intersection()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 4, 5, 6 };

			List<int> exp = new List<int>() { };
			List<int> res = Sets.GetIntersection(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetIntersection_Equal_Sets()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 1, 2, 3 };

			List<int> exp = new List<int>() { 1, 2, 3 };
			List<int> res = Sets.GetIntersection(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetIntersection_One_Empty_Set()
		{
			List<int> setA = new List<int> { 1, 2, 3};
			List<int> setB = new List<int> { };

			List<int> exp = new List<int>() { };
			List<int> res = Sets.GetIntersection(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		// Testa GetDifference()

		[TestMethod()]
		public void GetDifference_Has_Difference_No_Intersection()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 4, 5, 6 };

			List<int> exp = new List<int>() { 1, 2, 3 };
			List<int> res = Sets.GetDifference(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetDifference_Has_Difference_Has_Intersection()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 3, 4, 5 };

			List<int> exp = new List<int>() { 1, 2 };
			List<int> res = Sets.GetDifference(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetDifference_Has_Difference_Has_Intersection_With_Duplicates()
		{
			List<int> setA = new List<int> { 1, 2, 3, 3 };
			List<int> setB = new List<int> { 3, 3, 4, 5 };

			List<int> exp = new List<int>() { 1, 2 };
			List<int> res = Sets.GetDifference(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}


		[TestMethod()]
		public void GetDifference_First_Set_Empty()
		{
			List<int> setA = new List<int> { };
			List<int> setB = new List<int> { 4, 5, 6 };

			List<int> exp = new List<int>() { };
			List<int> res = Sets.GetDifference(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetDifference_Second_Set_Empty()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { };

			List<int> exp = new List<int>() { 1, 2, 3 };
			List<int> res = Sets.GetDifference(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}


		// Testa ResIsValid()

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

		// Testa HasMember()

		[TestMethod()]
		public void HasMember_Int_Exists_In_Set()
		{
			List<int> testSet = new List<int>() { 1, 2, 3, 4, 5 };
			int expectedInt = 4;

			Assert.IsTrue(Sets.HasMember(testSet, expectedInt));
		}

		[TestMethod()]
		public void HasMember_Int_Does_Not_Exist_In_Set()
		{
			List<int> testSet = new List<int>() { 1, 2, 3, 4, 5 };
			int expectedInt = 17;

			Assert.IsFalse(Sets.HasMember(testSet, expectedInt));
		}

		[TestMethod()]
		public void HasMember_On_Empty_Set()
		{
			List<int> testSet = new List<int>() { };
			int expectedInt = 17;

			Assert.IsFalse(Sets.HasMember(testSet, expectedInt));
		}

		// Testa IsSubsetOf

		[TestMethod()]
		public void IsSubsetOf_Is_Subset()
		{
			List<int> superset = new List<int>() {1, 2, 3, 4, 5 };
			List<int> subset   = new List<int>() {1, 2, 3 };

			Assert.IsTrue(Sets.IsSubsetOf(subset, superset));
		}

		[TestMethod()]
		public void IsSubsetOf_Is_Not_Subset()
		{
			List<int> superset = new List<int>() { 1, 2, 3, 4, 5 };
			List<int> subset   = new List<int>() { 6, 7 };

			Assert.IsFalse(Sets.IsSubsetOf(subset, superset));
		}

		[TestMethod()]
		public void IsSubsetOf_Subset_Is_Empty_Set()
		{
			List<int> superset = new List<int>() { 1, 2, 3, 4, 5 };
			List<int> subset   = new List<int>() { };

			Assert.IsTrue(Sets.IsSubsetOf(subset, superset));
		}

		[TestMethod()]
		public void IsSubsetOf_Superset_Is_Empty_Set()
		{
			List<int> superset = new List<int>() { };
			List<int> subset = new List<int>() { 1, 2, 3, 4, 5 };

			Assert.IsFalse(Sets.IsSubsetOf(subset, superset));
		}

	}
}
