﻿using System.Collections.Generic;

namespace Sets
{
	public class Sets
	{
		public static List<int> GetUnion( List<int> setA, List<int> setB )
		{
			List<int> unionSet = new List<int>();

			foreach (int intA in setA)
			{
				if (!HasMember(setB, intA))
				{
					// A finns inte i B, lägg till A i unionen
					unionSet.Add(intA);
				}
			}

			foreach (int intB in setB)
			{
				unionSet.Add(intB);
			}

			unionSet.Sort();
			return unionSet;
		}

		public static List<int> GetIntersection(List<int> setA, List<int> setB)
		{
			List<int> intersectionSet = new List<int>();

			foreach (int intA in setA)
			{
				if (HasMember(setB, intA))
				{
					intersectionSet.Add(intA);
				}
			}

			intersectionSet.Sort();
			return intersectionSet;
		}

		public static List<int> GetDifference(List<int> setA, List<int> setB)
		{
			List<int> differenceSet = new List<int>();

			foreach (int intA in setA)
			{
				if (!HasMember(setB, intA))
				{
					// A finns inte i B, lägg till i differensen
					differenceSet.Add(intA);
				}
			}

			// Sortera och svara
			differenceSet.Sort();
			return differenceSet;
		}

		public static bool HasMember(List<int> setA, int elem)
		{
			foreach (int intA in setA)
			{
				if (intA == elem)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsSubsetOf(List<int> setA, List<int> setB)
		{
			foreach (int intA in setA)
			{
				if (!HasMember(setB, intA))
				{
					return false;
				}
			}

			return true;
		}

		public static void Main(string[] args)
		{

		}
	}
}
