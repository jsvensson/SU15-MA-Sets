﻿using System;
using System.Collections.Generic;
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
				bool exists = false;
				foreach (int intB in setB)
				{
					if (intA == intB)
					{
						// A finns i B, sluta söka
						exists = true;
						break;
					}
				}

				if (!exists)
				{
					// A finns inte i B, lägg till i unionen
					unionSet.Add(intA);
				}
			}

			// unionSet innehåller nu (A \ B)
			// Vi har sökt igenom hela A, lägg till allt från B
			foreach (int intB in setB)
			{
				unionSet.Add(intB);
			}

			// Sortera unionen innan vi returnerar den
			unionSet.Sort();
			return unionSet;
		}

		public static List<int> GetIntersection(List<int> setA, List<int> setB)
		{
			return new List<int>();
		}

		public static List<int> GetDifference(List<int> setA, List<int> setB)
		{
			return new List<int>();
		}

		public static bool HasMember(List<int> setA, int elem)
		{
			return true;
		}

		public static bool IsSubsetOf(List<int> setA, List<int> setB)
		{
			return true;
		}

		public static void Main(string[] args)
		{

		}
	}
}
