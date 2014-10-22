using nilnul.num.natural.prime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{


	/// <summary>
	/// this stands a prime number.
	/// </summary>
	/// 
	public partial class IsPrime
		:nilnul.bit.AdjectiveI3<Plural2.Noun>
	{

		public bool be(NotNull2<bit.AdjectiveSuite<Natural_bigInteger, PluralAdj, Natural_bigInteger.Eq>.Noun> val)
		{
			return prime.SetX2.IsPrime(val.val);
			throw new NotImplementedException();
		}
	}

	public partial class Prime3
		:nilnul.bit.AdjectiveTypeEq2<Plural2.Noun,IsPrime,Prime3,Plural2.Noun.Eq>
		
	{

		public Prime3(Plural2.Noun p)
			:base(p)
		{
			
		}

		public Prime3(BigInteger b)
			:this(new Natural_bigInteger(b))
		{
		}


		public Prime3(Natural_bigInteger n)
			:this(new Plural2.Noun(n))
		{
		}
					
					
					
	




	}
}
