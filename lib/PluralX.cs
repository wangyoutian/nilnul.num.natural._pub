using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{

	static public partial class PluralX
	{
		static public bool IsPlural(this Natural n)
		{
			return n.val > 1;
		}
		static public bool Is(this Natural n)
		{
			return n.val > 1;
		}

		static public bool IsPlural(this PositiveNatural2 p)
		{
			return p.val.val > 1;
		}
		static public bool IsPlural(this BigInteger p)
		{
			return p > 1;
		}
		static public bool Is(BigInteger p)
		{
			return p > 1;
		}
		static public bool Is(long p)
		{
			return p > 1;
		}
		static public bool Is(int p)
		{
			return p > 1;
		}

		static public bool NotIsPlural(this PositiveNatural2 p)
		{
			return !IsPlural(p);
		}
		static public bool NotIsPlural(this BigInteger p)
		{
			return !IsPlural(p);
		}
		static public bool Not(this BigInteger p)
		{
			return !IsPlural(p);
		}
		static public bool Not(int p)
		{
			return !IsPlural(p);
		}


		static public void Assert(PositiveNatural2 p)
		{

			if (NotIsPlural(p))
			{
				throw new Exception("Not Plural");

			}

		}
		static public void Assert(BigInteger p)
		{

			if (NotIsPlural(p))
			{
				throw new Exception("Not Plural");

			}

		}

	}
}
