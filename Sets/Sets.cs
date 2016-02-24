using System;
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
					// A finns inte i B, lägg till A i unionen
					unionSet.Add(intA);
				}
			}

			// unionSet innehåller nu (A \ B)
			// Vi har sökt igenom hela A, lägg till allt från B som inte redan finns i unionen
			foreach (int intB in setB)
			{
				bool exists = false;
				foreach (int unionInt in unionSet)
				{
					exists = (intB == unionInt);
					break;
				}
				if (!exists)
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
				bool existsInB = false;
				foreach (int intB in setB)
				{
					if (intA == intB)
					{
						// element A finns i B
						existsInB = true;
						break;
					}
				}

				// Om A finns i B...
				if (existsInB)
				{
					// Hantera dubletter - finns intA redan som element i snittet?
					bool alreadyAdded = false;
					foreach (int i in intersectionSet)
					{
						if (intA != i) continue;
						alreadyAdded = true;
						break;
					}
										
					// lägg till intA om den inte redan finns som element i snittet
					if (!alreadyAdded)
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
				if (!Sets.HasMember(setB, intA))
				{
					exists = false;
				}
			}

			return exists;
		}

		public static void Main(string[] args)
		{

		}
	}
}
