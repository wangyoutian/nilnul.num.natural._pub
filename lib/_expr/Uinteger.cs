using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace nilnul.num.natural
{
	public partial class Uinteger
	{
		static public bool Is(long longInteger) {

			if (longInteger<0)
			{
				return false;
				
			}
			return true;
		
		}

		static public bool Is(BigInteger b) {
			if (b<0)
			{
				return false;
				
			}
			return true;
		
		}
	}
}
