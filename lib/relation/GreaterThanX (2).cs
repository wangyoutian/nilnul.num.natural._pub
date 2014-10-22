using System;
using System.Net;
using System.Numerics;

namespace nilnul.num.natural.relation
{
	static public partial class GreaterThanX
	{
		static public bool GreaterThan(this Natural a, Natural b)
		{

			return a.val > b.val;


		}

		static public bool GreaterThan(this Natural a, uint b)
		{

			return a.val > b;

		}

		static public bool GreaterThan(this BigInteger a, Infinite b)
		{

			return false;
		}

		static public bool GreaterThan(this Infinite b,  BigInteger a)
		{

			return true;
		}

		





		static public bool GreaterThan(this NaturalI a, NaturalI b)
		{

			if (a is Natural)
			{
				if (b is Natural)
				{
					return GreaterThanX.GreaterThan((Natural)a, (Natural)b);

				}

			}
			throw new Exception();

		}







		static public bool GreaterThan(this NaturalI a, ExtendedNaturalI b)
		{
			if (b is NaturalI)
			{
				return GreaterThan(a, (NaturalI)b);
			}
			else if (b is Infinite)
			{
				return false;

			}
			else
			{
				throw new Exception();
			}
		}

		static public bool GreaterThan(this ExtendedNaturalI a, ExtendedNaturalI b)
		{

			if (a is NaturalI)
			{
				if (b is NaturalI)
				{
					return GreaterThan((NaturalI)a, (NaturalI)b);

				}
				else if (b is Infinite)
				{
					return false;

				}
				else
				{
					throw new Exception();
				}


			}
			throw new Exception();

		}

	}
}
