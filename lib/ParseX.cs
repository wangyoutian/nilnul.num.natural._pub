using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural
{
	public partial class ParseX
	{
		static public Natural_bigInteger EvalFroBinary(string x) {

			BigInteger r = 0;
	//		var enumerator = x.Reverse().GetEnumerator();
			var enumerator = x.Trim().GetEnumerator();

			while (enumerator.MoveNext())
			{
				r = r * 2;
				if (enumerator.Current=='1')
				{
					r ++;
					continue;
					
				}
				if (enumerator.Current=='0')
				{
					
					
					continue;
				}
				throw new ArgumentException("only 1 or 0 can appear.");
			
				
			}
			return new Natural_bigInteger( r);

			throw new NotImplementedException();
		
		}


	}
}
