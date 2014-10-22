using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural.prime._1
{


	/// <summary>
	/// this stands a prime number.
	/// </summary>

	public partial class Prime:Plural
	{

	
	

		public override BigInteger val
		{
			get {
				return _val;
			
			}
			set {

				if (prime.PrimeX.Is(value))
				{
					_val = value;
					
				}

				throw new ArgumentException();
			
			}
		}
		
		public Prime(Plural n):base(n.val)
		{
			PrimeX.Assert(n);

		
			


		}

		public Prime(long n):this(new Plural(n))
		{
			

		}

		public Prime(BigInteger bi)
			:this(new Plural(bi))
		{

		}

					


		/// <summary>
		/// this is an ideal table, i.e., it can hold unlimited primes; while the table implemented in sql serer, due to the capacity constraints there, can only hold bounded primes.
		/// </summary>

	}
}
