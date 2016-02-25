﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			// unionSet innehåller nu (A \ B)
			// Vi har sökt igenom hela A, lägg till allt från B som inte redan finns i unionen
			foreach (int intB in setB)
			{
				if (!HasMember(unionSet, intB))
				{
					unionSet.Add(intB);
				}
			}

			// Sortera unionen innan vi returnerar den
			unionSet.Sort();
			return unionSet;
		}

		public static List<int> GetIntersection(List<int> setA, List<int> setB)
		{
			List<int> intersectionSet = new List<int>();

			foreach (int intA in setA)
			{
				// Om intA finns i setB...
				if (HasMember(setB, intA))
				{
					// Hantera dubletter - finns intA redan som element i snittet?
					// Kan uppstå om samma element n finns i både setA och setB										
					// Om inte, lägg till intA i snittet.
					if (!HasMember(intersectionSet, intA))
					{
						intersectionSet.Add(intA);
					}
				}
			}

			// Sortera och svara
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
			return setA.Any(intA => intA == elem);
		}

		public static bool IsSubsetOf(List<int> setA, List<int> setB)
		{
			bool exists = true;
			foreach (int intA in setA)
			{
				if (!HasMember(setB, intA))
				{
					exists = false;
					break;
				}
			}

			return exists;
		}

		public static void Main(string[] args)
		{

		}
	}
}
