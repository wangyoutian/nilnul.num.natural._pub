using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using nilnul.bit;
namespace nilnul.num.natural
{

	static public partial class NaturalX
	{

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>null if not a ulong number.</returns>
		static public ulong? Parse(string str) {
            ulong output;

            var converted= ulong.TryParse(str, out output);
            if (converted)
            {
                return output;
                
            }
            return null;
		
		}
		

		static public bool Is(long longInteger)
		{

			if (longInteger < 0)
			{
				return false;

			}
			return true;

		}

        static public void Assert(BigInteger b) {
			nilnul.bit.AssertX.AssertFuncTrue<BigInteger>(Is, b);
        }


		static public bool Is(BigInteger b)
		{
			if (b < 0)
			{
				return false;

			}
			return true;

		}
		static public BigInteger ToBigint(this NaturalI n) {

			if (n is NaturalBigint)
			{
				return (((NaturalBigint)n).toBigint());
				
			}
			if (n is PositiveNatural)
			{
				return ((PositiveNatural)n).toBigint();

				
			}

			else 
			{
				throw new Exception("Unknown type.");
				
			}
				
		
		}

		
	
		static public Natural ToNatural(this BigInteger a)
		{
			return new Natural(a);

		}

		static public Natural AsNatural(this BigInteger a)
		{
			return new Natural(a);

		}

		static public Natural ToUinteger(this uint a)
		{
			return new Natural(a);
		}

		static public Natural ToNatural(this int a)
		{
			return new Natural(a);
		}

		static public int ToInt(this BigInteger a)
		{
			return (int)a;

		}



		static public int ToInt(this Natural a)
		{
			return (int)(a.val);
		}

		static public BigInteger ToBigInt(this Natural a)
		{
			return a.val;
		}



	}

}
