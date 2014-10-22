using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural
{
	/// <summary>
	/// Trichotomy 
	/// </summary>
	public enum Sign
	{
		Gt=1,
		Eq=0,
		Lt=-1

		
	}

	static public class SignX {
		static public Sign ToSign(this int x) {

			if (x>0)
			{
				return Sign.Gt;
				
			}
			if (x==0)
			{
				return Sign.Eq;
				
			}
			return Sign.Lt;
		
		}

		static public Sign ToSign(BigInteger x) {

			if (x>0)
			{
				return Sign.Gt;

			} if (x==0)
			{
				return Sign.Eq;
				
			}
			return Sign.Lt;
 


		
		}
	}
}
