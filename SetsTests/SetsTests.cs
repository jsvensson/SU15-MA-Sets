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
			List<int> sortedExp = exp.ToList();
			List<int> sortedRes = res.ToList();
			sortedExp.Sort();
			sortedRes.Sort();

			return sortedExp.SequenceEqual(sortedRes);
		}

		// Testa GetUnion()

		[TestMethod()]
		public void GetUnion__Sizes_3_And_2()
		{
			List<int> setA = new List<int> { 1, 7, 3 };
			List<int> setB = new List<int> { 2, 5 };
			List<int> exp = new List<int> { 2, 1, 3, 7, 5 };

			List<int> res = Sets.GetUnion(setA, setB);

			Assert.IsTrue( ResIsValid(res, exp) );
		}

		[TestMethod()]
		public void GetUnion__Identical_Sets()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 1, 2, 3 };
			List<int> exp = new List<int> { 1, 2, 3 };
			List<int> res = Sets.GetUnion(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetUnion__Element_Order_Shouldnt_Matter()
		{
			List<int> setA = new List<int> { 1, 7, 3 };
			List<int> setB = new List<int> { 2, 5 };

			List<int> exp = new List<int> { 7, 5, 1, 2, 3 };
			List<int> res = Sets.GetUnion(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetUnion__Empty_Sets()
		{
			List<int> setA = new List<int> { };
			List<int> setB = new List<int> { };
			List<int> exp = new List<int> { };
			List<int> res = Sets.GetUnion(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		public void GetUnion__First_Set_Is_Empty()
		{
			List<int> setA = new List<int> { };
			List<int> setB = new List<int> { 1, 2, 3 };
			List<int> exp = new List<int> { 1, 2, 3 };
			List<int> res = Sets.GetUnion(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		public void GetUnion__Second_Set_Is_Empty()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { };
			List<int> exp = new List<int> { 1, 2, 3 };
			List<int> res = Sets.GetUnion(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		// Testa GetIntersection()

		[TestMethod()]
		public void GetIntersection__Has_Intersection_No_Duplicates()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 3, 4, 5 };

			List<int> exp = new List<int>() { 3 };
			List<int> res = Sets.GetIntersection(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetIntersection__No_Intersection()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 4, 5, 6 };

			List<int> exp = new List<int>() { };
			List<int> res = Sets.GetIntersection(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetIntersection__Equal_Sets()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 1, 2, 3 };

			List<int> exp = new List<int>() { 1, 2, 3 };
			List<int> res = Sets.GetIntersection(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetIntersection__SetA_Is_Empty()
		{
			List<int> setA = new List<int> { };
			List<int> setB = new List<int> { 1, 2, 3 };

			List<int> exp = new List<int>() { };
			List<int> res = Sets.GetIntersection(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetIntersection__SetB_Is_Empty()
		{
			List<int> setA = new List<int> { 1, 2, 3};
			List<int> setB = new List<int> { };

			List<int> exp = new List<int>() { };
			List<int> res = Sets.GetIntersection(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		// Testa GetDifference()

		[TestMethod()]
		public void GetDifference__Has_Difference__No_Intersection()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 4, 5, 6 };

			List<int> exp = new List<int>() { 1, 2, 3 };
			List<int> res = Sets.GetDifference(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetDifference__Has_Difference__Has_Intersection()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 3, 4, 5 };

			List<int> exp = new List<int>() { 1, 2 };
			List<int> res = Sets.GetDifference(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetDifference__Has_Difference__Has_Intersection_With_Duplicates()
		{
			List<int> setA = new List<int> { 1, 2, 3, 3 };
			List<int> setB = new List<int> { 3, 3, 4, 5 };

			List<int> exp = new List<int>() { 1, 2 };
			List<int> res = Sets.GetDifference(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}


		[TestMethod()]
		public void GetDifference__SetA_Is_Empty()
		{
			List<int> setA = new List<int> { };
			List<int> setB = new List<int> { 4, 5, 6 };

			List<int> exp = new List<int>() { };
			List<int> res = Sets.GetDifference(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}

		[TestMethod()]
		public void GetDifference__SetB__Is_Empty()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { };

			List<int> exp = new List<int>() { 1, 2, 3 };
			List<int> res = Sets.GetDifference(setA, setB);

			Assert.IsTrue(ResIsValid(res, exp));
		}


		// Testa ResIsValid()

		[TestMethod()]
		public void ResIsValid__Equal_Sorted_Sets()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 1, 2, 3 };

			Assert.IsTrue( ResIsValid(setA, setB) );
		}

		[TestMethod()]
		public void ResIsValid__Element_Order_Shouldnt_Matter()
		{
			List<int> exp = new List<int> { 1, 2, 3 };
			List<int> res = new List<int> { 3, 2, 1 };

			Assert.IsTrue(ResIsValid(exp, res));
		}


		[TestMethod()]
		public void ResIsValid__Not_Equal_Sets()
		{
			List<int> setA = new List<int> { 1, 2, 3 };
			List<int> setB = new List<int> { 1, 2 };

			Assert.IsFalse(ResIsValid(setA, setB));
		}

		[TestMethod()]
		public void ResIsValid__SetA_Is_Empty()
		{
			List<int> setA = new List<int> { };
			List<int> setB = new List<int> { 1, 2, 3 };

			Assert.IsFalse(ResIsValid(setA, setB));
		}

		[TestMethod()]
		public void ResIsValid__SetB_Is_Empty()
		{
			List<int> setA = new List<int> { 1, 2, 3};
			List<int> setB = new List<int> { };

			Assert.IsFalse(ResIsValid(setA, setB));
		}

		// Testa HasMember()

		[TestMethod()]
		public void HasMember__Element_Exists_In_Set()
		{
			List<int> testSet = new List<int>() { 1, 2, 3, 4, 5 };
			int expectedInt = 4;

			Assert.IsTrue(Sets.HasMember(testSet, expectedInt));
		}

		[TestMethod()]
		public void HasMember__Element_Does_Not_Exist_In_Set()
		{
			List<int> testSet = new List<int>() { 1, 2, 3, 4, 5 };
			int expectedInt = 17;

			Assert.IsFalse(Sets.HasMember(testSet, expectedInt));
		}

		[TestMethod()]
		public void HasMember__Empty_Set()
		{
			List<int> testSet = new List<int>() { };
			int expectedInt = 17;

			Assert.IsFalse(Sets.HasMember(testSet, expectedInt));
		}

		// Testa IsSubsetOf

		[TestMethod()]
		public void IsSubsetOf__Is_Subset()
		{
			List<int> superset = new List<int>() {1, 2, 3, 4, 5 };
			List<int> subset   = new List<int>() {1, 2, 3 };

			Assert.IsTrue(Sets.IsSubsetOf(subset, superset));
		}

		[TestMethod()]
		public void IsSubsetOf__Is_Not_Subset()
		{
			List<int> superset = new List<int>() { 1, 2, 3, 4, 5 };
			List<int> subset   = new List<int>() { 6, 7 };

			Assert.IsFalse(Sets.IsSubsetOf(subset, superset));
		}

		[TestMethod()]
		public void IsSubsetOf__Subset_Is_Empty()
		{
			List<int> superset = new List<int>() { 1, 2, 3, 4, 5 };
			List<int> subset   = new List<int>() { };

			Assert.IsTrue(Sets.IsSubsetOf(subset, superset));
		}

		[TestMethod()]
		public void IsSubsetOf__Superset_Is_Empty()
		{
			List<int> superset = new List<int>() { };
			List<int> subset = new List<int>() { 1, 2, 3, 4, 5 };

			Assert.IsFalse(Sets.IsSubsetOf(subset, superset));
		}

	}
}
