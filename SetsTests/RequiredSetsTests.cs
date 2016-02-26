// *************************************
// *************************************

// YOUR PROJECT ASSIGNMENT MUST PASS ALL TESTS IN THIS FILE.

// WARNING: YOU ARE *NOT* ALLOWED TO MAKE ANY CHANGES TO THIS FILE AT ALL!
// IF YOU MAKE CHANGES TO THIS FILE THEN YOUR SUBMISSION WON'T BE ACCEPTED
// AND YOU WILL HAVE TO RESUBMIT!

// THIS FILE CONTAINS UNIT TESTS THAT YOUR PROJECT MUST PASS. IF YOUR
// PROJECT FAILS ANY OF THESE TESTS, THEN YOUR PROJECT CONTAINS ERRORS AND
// YOU MUST FIX THEM. YOU ARE *NOT* ALLOWED TO MODIFY THE FAILING TEST.

// If you strongly feel that one of the unit tests in this file fails
// because the test itself contains an error then contact me (Arash),
// but DON'T change the test unless I allow you to.

// *************************************
// *************************************

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
	public class RequiredSetsTests
	{
		[TestMethod()]
		public void ResIsValid__Empty_Sets__True()
		{
			Assert.IsTrue( SetsTests.ResIsValid( new List<int>(), new List<int>() ) );
		}

		[TestMethod()]
		public void ResIsValid__Empty_Set__One_elem__False()
		{
			Assert.IsFalse(
				SetsTests.ResIsValid( new List<int>(), new List<int>() { 1 } )
			);
		}

		[TestMethod()]
		public void ResIsValid__One_Elem__Empty_Set__False()
		{
			Assert.IsFalse(
				SetsTests.ResIsValid( new List<int>() { 1 }, new List<int>() )
			);
		}

		[TestMethod()]
		public void ResIsValid__One_Elem__False()
		{
			Assert.IsFalse(
				SetsTests.ResIsValid( new List<int>() { 1 }, new List<int>() { 4 } )
			);
		}

		[TestMethod()]
		public void ResIsValid__One_Pos_Elem__True()
		{
			Assert.IsTrue(
				SetsTests.ResIsValid( new List<int>() { 7 }, new List<int>() { 7 } )
			);
		}

		[TestMethod()]
		public void ResIsValid__One_Neg_Elem__One_Pos_Elem__False()
		{
			Assert.IsFalse(
				SetsTests.ResIsValid( new List<int>() { -7 }, new List<int>() { 7 } )
			);
		}

		[TestMethod()]
		public void ResIsValid__One_Elem_Dupl__Same_Elem_Once__False()
		{
			Assert.IsFalse(
				SetsTests.ResIsValid( new List<int>() { 8, 8 }, new List<int>() { 8 } )
			);
		}

		[TestMethod()]
		public void ResIsValid__Two_Elems_Same_Order__True()
		{
			Assert.IsTrue(
				SetsTests.ResIsValid(
					new List<int>() { 432, 213 },
					new List<int>() { 432, 213 }
				)
			);
		}

		[TestMethod()]
		public void ResIsValid__Two_Elems_Diff_Order__True()
		{
			Assert.IsTrue(
				SetsTests.ResIsValid(
					new List<int>() { 213, 432 },
					new List<int>() { 432, 213 }
				)
			);
		}

		[TestMethod()]
		public void ResIsValid__Three_Elems_One_Dupl__Same_Elems_No_Dupl__False()
		{
			Assert.IsFalse(
				SetsTests.ResIsValid(
					new List<int>() { 8675, 695, 8675 },
					new List<int>() { 695, 8675 }
				)
			);
		}

		[TestMethod()]
		public void ResIsValid__Large_And_Small_Elems__True()
		{
			Assert.IsTrue(
				SetsTests.ResIsValid(
					new List<int>() {
						int.MaxValue,
						int.MaxValue - 1,
						int.MinValue,
						int.MinValue + 1
					},
					new List<int>() {
						int.MaxValue - 1,
						int.MaxValue,
						int.MinValue + 1,
						int.MinValue
					}
				)
			);
		}

		[TestMethod()]
		public void ResIsValid__Sets_With_50000_Elems__True()
		{
			Random rand = new Random(0);
			List<int> firstList = new List<int>();

			for( uint i = 0; i < 50000; i++ )
			{
				firstList.Add( rand.Next() );
			}

			List<int> secondList = new List<int>( firstList );

			Assert.IsTrue( SetsTests.ResIsValid( firstList, secondList ) );
		}

		[TestMethod()]
		public void ResIsValid__50001_Elems_One_Dupl__Same_Elems_No_Dupl__False()
		{
			Random rand = new Random(0);
			List<int> firstList = new List<int>();

			for ( uint i = 0; i < 50000; i++ )
			{
				firstList.Add( rand.Next() );
			}

			List<int> secondList = new List<int>(firstList);
			firstList.Add( firstList[ 15000 ] );

			Assert.IsFalse( SetsTests.ResIsValid( firstList, secondList ) );
		}

		[TestMethod()]
		public void GetUnion__Empty_Sets()
		{
			List<int> setA = new List<int>();
			List<int> setB = new List<int>();

			List<int> union = Sets.GetUnion( setA, setB );

			Assert.IsTrue( SetsTests.ResIsValid( union, new List<int>() ) );
		}

		[TestMethod()]
		public void GetUnion__No_Elems__One_Elem()
		{
			List<int> setA = new List<int>();
			List<int> setB = new List<int>() { 543 };

			List<int> union = Sets.GetUnion( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid( union, new List<int>() { 543 } )
			);
		}

		[TestMethod()]
		public void GetUnion__One_Elem__No_Elems()
		{
			List<int> setA = new List<int>() { 543 };
			List<int> setB = new List<int>();

			List<int> union = Sets.GetUnion( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid( union, new List<int>() { 543 } )
			);
		}

		[TestMethod()]
		public void GetUnion__One_Elem__Same_Elem()
		{
			List<int> setA = new List<int>() { 543 };
			List<int> setB = new List<int>() { 543 };

			List<int> union = Sets.GetUnion( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid( union, new List<int>() { 543 } )
			);
		}

		[TestMethod()]
		public void GetUnion__One_Elem__Another_Elem()
		{
			List<int> setA = new List<int>() { 543 };
			List<int> setB = new List<int>() { -543 };

			List<int> union = Sets.GetUnion( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid( union, new List<int>() { 543, -543 } )
			);
		}

		[TestMethod()]
		public void GetUnion__Four_Elems__No_Elems()
		{
			List<int> setA = new List<int>() { 675, -546347, 0, 1 };
			List<int> setB = new List<int>();

			List<int> union = Sets.GetUnion( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid( union, new List<int>() { 675, -546347, 0, 1 } )
			);
		}

		[TestMethod()]
		public void GetUnion__Four_Elems__Same_Elems_In_Diff_Order()
		{
			List<int> setA = new List<int>() { 675, -546347, 0, 1 };
			List<int> setB = new List<int>() { 1, -546347, 0, 675 };

			List<int> union = Sets.GetUnion( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid( union, new List<int>() { 675, -546347, 0, 1 } )
			);
		}

		[TestMethod()]
		public void GetUnion__Six_Elems__Eight_Elems__Have_Common_Elems()
		{
			List<int> setA = new List<int>() { 675, -546347, 0, 1, 5843, -343 };
			List<int> setB =
				new List<int>() { 584, 326, 675, -342, 3, 5843, 34, 654 }
			;

			List<int> union = Sets.GetUnion( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid(
					union,
					new List<int>() {
						675, -546347, 0, 1, 5843, -343, 584,
						326, -342, 3, 34, 654
					}
				)
			);
		}

		[TestMethod()]
		public void GetUnion__Four_Elems__Two_Elems__Args_Are_Unchanged()
		{
			List<int> setA = new List<int>() { 675, -546347, 0, 1 };
			List<int> setB = new List<int>() { 584, 326 };

			Sets.GetUnion(setA, setB);

			Assert.IsTrue(
					setA.SequenceEqual( new List<int>() { 675, -546347, 0, 1 } )
			);

			Assert.IsTrue(
				setB.SequenceEqual( new List<int>() { 584, 326 } )
			);
		}

		[TestMethod()]
		public void GetIntersection__Four_Elems__Two_Elems__No_Common_Elems()
		{
			List<int> setA = new List<int>() { 4372, 21, -343, 23 };
			List<int> setB = new List<int>() { 654, 32 };

			List<int> inters = Sets.GetIntersection( setA, setB );

			Assert.IsTrue( SetsTests.ResIsValid( inters, new List<int>() ) );
		}

		[TestMethod()]
		public void GetIntersection__Three_Elems__Two_Elems__One_Common_Elem()
		{
			List<int> setA = new List<int>() { 584, 22, -343 };
			List<int> setB = new List<int>() { -343, 22 };

			List<int> inters = Sets.GetIntersection( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid( inters, new List<int>() { -343, 22 } )
			);
		}

		[TestMethod()]
		public void GetIntersection__Same_Six_Elems__Diff_Order()
		{
			List<int> setA = new List<int>() { 584, 22, -343, 3422, 123, 77 };
			List<int> setB = new List<int>() { -343, 22, 584, 77, 123, 3422 };

			List<int> inters = Sets.GetIntersection( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid(
					inters, new List<int>() { -343, 22, 584, 77, 123, 3422 }
				)
			);
		}

		[TestMethod()]
		public void GetIntersection__Empty_Sets()
		{
			List<int> setA = new List<int>();
			List<int> setB = new List<int>();

			List<int> inters = Sets.GetIntersection( setA, setB );

			Assert.IsTrue( SetsTests.ResIsValid( inters, new List<int>() ) );
		}

		[TestMethod()]
		public void GetIntersection__No_Elems__Three_Elems()
		{
			List<int> setA = new List<int>();
			List<int> setB = new List<int>() { 4322, 123, 1 };

			List<int> inters = Sets.GetIntersection( setA, setB );

			Assert.IsTrue( SetsTests.ResIsValid( inters, new List<int>() ) );
		}

		[TestMethod()]
		public void GetIntersection__Three_Elems__No_Elems()
		{
			List<int> setA = new List<int>() { 4322, 123, 1 };
			List<int> setB = new List<int>();

			List<int> inters = Sets.GetIntersection( setA, setB );

			Assert.IsTrue( SetsTests.ResIsValid( inters, new List<int>() ) );
		}

		[TestMethod()]
		public void GetIntersection__Four_Elems__Two_Elems__Args_Are_Unchanged()
		{
			List<int> setA = new List<int>() { 675, -546347, 0, 1 };
			List<int> setB = new List<int>() { 584, 326 };

			Sets.GetIntersection(setA, setB);

			Assert.IsTrue(
					setA.SequenceEqual( new List<int>() { 675, -546347, 0, 1 } )
			);

			Assert.IsTrue(
				setB.SequenceEqual( new List<int>() { 584, 326 } )
			);
		}

		[TestMethod()]
		public void GetDifference__Empty_Sets()
		{
			List<int> setA = new List<int>();
			List<int> setB = new List<int>();

			List<int> inters = Sets.GetIntersection( setA, setB );

			Assert.IsTrue( SetsTests.ResIsValid( inters, new List<int>() ) );
		}

		[TestMethod()]
		public void GetDifference__One_Elem__No_Elems()
		{
			List<int> setA = new List<int>() { 4324 };
			List<int> setB = new List<int>();

			List<int> inters = Sets.GetDifference( setA, setB );

			Assert.IsTrue( SetsTests.ResIsValid( inters, new List<int>() { 4324 } ) );
		}

		[TestMethod()]
		public void GetDifference__No_Elems__One_Elem()
		{
			List<int> setA = new List<int>();
			List<int> setB = new List<int>() { 4324 };

			List<int> inters = Sets.GetDifference( setA, setB );

			Assert.IsTrue( SetsTests.ResIsValid( inters, new List<int>() ) );
		}

		[TestMethod()]
		public void GetDifference__One_Elem__Same_Elem()
		{
			List<int> setA = new List<int>() { 4324 };
			List<int> setB = new List<int>() { 4324 };

			List<int> inters = Sets.GetDifference( setA, setB );

			Assert.IsTrue( SetsTests.ResIsValid( inters, new List<int>() ) );
		}

		[TestMethod()]
		public void GetDifference__Three_Elems__Two_Diff_Elems()
		{
			List<int> setA = new List<int>() { 34533, 2324, 123 };
			List<int> setB = new List<int>() { 43, 12 };

			List<int> inters = Sets.GetDifference( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid( inters, new List<int>() { 34533, 2324, 123 } )
			);
		}

		[TestMethod()]
		public void GetDifference__Three_Elems__Two_Elems__One_Elem_Common()
		{
			List<int> setA = new List<int>() { 34533, 2324, 123 };
			List<int> setB = new List<int>() { 543, 2324 };

			List<int> inters = Sets.GetDifference( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid( inters, new List<int>() { 34533, 123 } )
			);
		}

		[TestMethod()]
		public void GetDifference__No_Elems__Four_Elems()
		{
			List<int> setA = new List<int>() { };
			List<int> setB = new List<int>() { 34533, 2324, 123, 543 };

			List<int> inters = Sets.GetDifference( setA, setB );

			Assert.IsTrue(
				SetsTests.ResIsValid( inters, new List<int>() { } )
			);
		}

		[TestMethod()]
		public void GetDifference__Four_Elems__Two_Elems__Args_Are_Unchanged()
		{
			List<int> setA = new List<int>() { 675, -546347, 0, 1 };
			List<int> setB = new List<int>() { 584, 326 };

			Sets.GetDifference( setA, setB );

			Assert.IsTrue(
					setA.SequenceEqual( new List<int>() { 675, -546347, 0, 1 } )
			);

			Assert.IsTrue(
				setB.SequenceEqual( new List<int>() { 584, 326 } )
			);
		}

		[TestMethod()]
		public void HasMember__Empty_Set__False()
		{
			List<int> set = new List<int>();

			Assert.IsFalse( Sets.HasMember( set, 4985984 ) );
		}

		[TestMethod()]
		public void HasMember__One_Elem__Search_For_Negated_Elem__False()
		{
			List<int> set = new List<int>() { 4985984 };

			Assert.IsFalse( Sets.HasMember( set, -4985984 ) );
		}

		[TestMethod()]
		public void HasMember__One_Elem__True()
		{
			List<int> set = new List<int>() { 4985984 };

			Assert.IsTrue( Sets.HasMember( set, 4985984 ) );
		}

		[TestMethod()]
		public void HasMember__Two_Elems__Search_For_First_Elem__True()
		{
			List<int> set = new List<int>() { 4985984, 43534 };

			Assert.IsTrue( Sets.HasMember( set, 4985984 ) );
		}

		[TestMethod()]
		public void HasMember__Two_Elems__Search_For_Secon_Elem__True()
		{
			List<int> set = new List<int>() { 4985984, 43534 };

			Assert.IsTrue( Sets.HasMember( set, 43534 ) );
		}

		[TestMethod()]
		public void HasMember__Six_Elems__Search_For_Ultimate_Elem__True()
		{
			List<int> set =
				new List<int>() { 4985984, 43534, -4535354, 2743, -867, 544 }
			;

			Assert.IsTrue( Sets.HasMember( set, 544 ) );
		}

		[TestMethod()]
		public void HasMember__Six_Elems__Search_For_Pen_Ultimate_Elem__True()
		{
			List<int> set =
				new List<int>() { 4985984, 43534, -4535354, 2743, -867, 544 }
			;

			Assert.IsTrue( Sets.HasMember( set, -867 ) );
		}

		[TestMethod()]
		public void HasMember__Six_Elems__Search_For_Second_Elem__True()
		{
			List<int> set =
				new List<int>() { 4985984, 43534, -4535354, 2743, -867, 544 }
			;

			Assert.IsTrue( Sets.HasMember( set, 43534 ) );
		}

		[TestMethod()]
		public void HasMember__Four_Elems__Arg_Is_Unchanged()
		{
			List<int> set = new List<int>() { 675, -546347, 0, 1 };

			Sets.HasMember( set, 68594 );

			Assert.IsTrue(
					set.SequenceEqual( new List<int>() { 675, -546347, 0, 1 } )
			);
		}
	}
}
