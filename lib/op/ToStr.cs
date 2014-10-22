using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.op
{
	public partial class ToStrX
	{
		static public string Do(BigInteger n_nonNeg, Radix radix)
		{
			if (n_nonNeg == 0)
			{
				return "0";

			}

			BigInteger remainder;//=n_nonNeg;
			//n_nonNeg = BigInteger.DivRem(n_nonNeg, radix.count, out remainder);

			StringBuilder r = new StringBuilder();

			while (n_nonNeg != 0)
			{
				n_nonNeg = BigInteger.DivRem(n_nonNeg, radix.count, out remainder);

				r.Insert(0,
					radix.digits.ElementAt((int)remainder).ToString()
				);


			}
			return r.ToString();

		}

		static public string Do_0empty(BigInteger n_nonNeg, Radix radix)
		{
			if (n_nonNeg == 0)
			{
				return "";

			}

			BigInteger remainder;//=n_nonNeg;
			//n_nonNeg = BigInteger.DivRem(n_nonNeg, radix.count, out remainder);

			StringBuilder r = new StringBuilder();

			while (n_nonNeg != 0)
			{
				n_nonNeg = BigInteger.DivRem(n_nonNeg, radix.count, out remainder);

				r.Insert(0,
					radix.digits.ElementAt((int)remainder).ToString()
				);


			}
			return r.ToString();

		}

		static public string Do(BigInteger n_nonNeg, int radix_withinHex)
		{
			return Do(n_nonNeg, Radix.Create(radix_withinHex));

		}

		static public string Do(BigInteger n_nonNeg, BigInteger radix_withinHex)
		{
			return Do(n_nonNeg, Radix.Create(radix_withinHex));

		}


		static public string Do_binary(BigInteger n_nonNeg)
		{
			return Do(n_nonNeg, Radix.Binary.Singleton.Instance);

		}
		static public string Do_binary(int n_nonNeg)
		{
			return Do(n_nonNeg, Radix.Binary.Singleton.Instance);

		}
		static public string Do_binary0empty(BigInteger n_nonNeg)
		{
			return Do_0empty(n_nonNeg, Radix.Binary.Singleton.Instance);

		}
		static public string Do_binary0empty(int n_nonNeg)
		{
			return Do_0empty(n_nonNeg, Radix.Binary.Singleton.Instance);

		}

		static public string Do_oct(BigInteger n_nonNeg)
		{
			return Do(n_nonNeg, Radix.Oct.Binary.Singleton.Instance);

		}

		static public string Do_decimal(BigInteger n_nonNeg)
		{
			return Do(n_nonNeg, Radix.Decimal.Singleton.Instance);

		}

		static public string Do_hex(BigInteger n_nonNeg)
		{
			return Do(n_nonNeg, Radix.Hex.Singleton.Instance);

		}






	}
}
