using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace nilnul.num.natural.prime
{

	/// <summary>
	/// 
	/// </summary>
	/// 
	[Obsolete("see Prime.Collection")]
	public partial class Prime
	{

		/// <summary>
		/// this is an ideal table, i.e., it can hold unlimited primes; while the table implemented in sql serer, due to the capacity constraints there, can only hold bounded primes.
		/// </summary>
		public partial class Table
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="index"></param>
			/// <returns></returns>
			static public void PopulateToCover(Natural n)
			{

				if (n.val > long.MaxValue)
				{
					throw new ArgumentOutOfRangeException();

				}
				else
				{
					PrimeController120408.PopulateToCover((long)(n.val));
				}

			}

		


			static public bool IsPrime(Natural n)
			{
				PopulateToCover(n);
				return Contains(n);

			}

			

			static public bool Contains(Natural n)
			{
				return PrimeController120408.Contains((long)(n.val));

			}

			

			static public IEnumerable<Prime> SequenceUpTo(Natural n) {
 
				return PrimeController120408.SequenceUpTo((long)(n.val)).Select(c=>new Prime( c.num));
			}

			static public IEnumerable<Prime> SequenceUpTo(long n)
			{

				return SequenceUpTo(new Natural(n));
			}




		}

	}
}
