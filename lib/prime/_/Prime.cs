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

	public partial class Prime

	{

		public BigInteger toBigInteger() {
			return _val.toBigInteger();
		}
		private Natural _val;

		public Natural val
		{
			get { return _val; }
			set {

				if (IsPrime(value))
				{
					_val = value;
					
				}

				throw new ArgumentException();
			
			}
		}
		
		public Prime(Natural n)
		{
			val = n;

		}

		public Prime(long n)
		{
			val = new Natural(n);

		}

		public Prime(BigInteger bi)
			:this(new Natural(bi))
		{

		}

					


		static public bool IsPrime(Natural a)
		{
			///first check the PrimeTable
			///
			return Prime.Table.Contains(a);

		}

		static public bool Is(Natural a)
		{
			///first check the PrimeTable
			///
			return Prime.Table.Contains(a);

		}

		/// <summary>
		/// this is an ideal table, i.e., it can hold unlimited primes; while the table implemented in sql serer, due to the capacity constraints there, can only hold bounded primes.
		/// </summary>

	}
}
