using nilnul.num.natural.prime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural
{
	public partial class PrimitiveRoot
	{
		

		static public bool Is(int natural, int prime)
		{
			return Is((BigInteger)natural, (BigInteger)prime);

		}

		static public HashSet<BigInteger> GetRoots(
			BigInteger natural, BigInteger prime

			)
		{

			var r = new HashSet<BigInteger>();
			for (BigInteger i = 1; i < prime; i++)
			{
				var mod = nilnul.num.natural.op.PowX.Pow(natural, i).val % prime;
				r.Add(mod);

			}
			return r;

		}

		static public bool Is(BigInteger natural, BigInteger prime)
		{

			var r = GetRoots(natural, prime);

			if (r.Count == prime - 1)
			{
				return true;


			}
			return false;

			throw new NotImplementedException();

		}

	}
}
