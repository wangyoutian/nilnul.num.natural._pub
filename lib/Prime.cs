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

	public partial class Prime
		:
		nilnul.bit.AdjectiveTowardNoun3<Plural2.Noun,Prime>
	{
		public override bool be(NotNull2<Plural2.Noun> val)
		{	
			return prime.SetX2.IsPrime(val.val);
			throw new NotImplementedException();
		}

	
	}
}
