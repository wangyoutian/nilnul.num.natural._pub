using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural.prime
{


	/// <summary>
	/// this stands a prime number.
	/// </summary>

	public partial class PrimeX
	{




		static public bool Is(Natural a)
		{
			///first check the PrimeTable
			///
			return Set.IsPrime(a);

		}
		static public bool Is(Plural p) {
			return SetX2.IsPrime(p);
		
		}

	

		static public bool Is(BigInteger i) {

			return Is(new Plural(i));
		
		}

		static public bool Is(int i)
		{

			return Is(new Plural(i));

		}

		static public bool Not(Plural a) {
			return !Is(a);
		
		}

		static public void Assert(Plural n) {
			if (Not(n))
			{
				throw new Exception();

				
			}
		
		}

		static public void Assert(Natural n)
		{
			Assert(new Plural(n));

		}

	

		/// <summary>
		/// this is an ideal table, i.e., it can hold unlimited primes; while the table implemented in sql serer, due to the capacity constraints there, can only hold bounded primes.
		/// </summary>

	}
}
