using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{
	public partial class PluralAdj
		:
		
		nilnul.bit.AdjectiveI3<Natural_bigInteger>
	
	{



		public bool be(NotNull2<Natural_bigInteger> val)
		{
			return val.val > 1;
			throw new NotImplementedException();
		}
	}


	public partial class Plural2
	:
		nilnul.bit.AdjectiveSuite<Natural_bigInteger,PluralAdj,Natural_bigInteger.Eq>
	{

		
	}


}
