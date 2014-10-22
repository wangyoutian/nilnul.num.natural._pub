using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural
{
    public class IsZero
    {


		static public bool Eval(Natural2 n)
		{

			return n.val == 0;

		}
		static public bool Eval(Natural_bigInteger n)
		{

			return n.val == 0;

		}

        

		static public bool Eval(NaturalI a)
		{

			if (a is natural.NaturalBigint)
			{
				NaturalBigint b = (NaturalBigint)a;

				return b.val == 0;

			}
			if (a is natural.PositiveNatural)
			{
				return false;
				
			}
			if (a is Natural2)
			{
				return Eval(a as Natural2);
				
			}
			if (a is Natural_bigInteger)
			{
				return Eval(a as Natural_bigInteger);
				
			}


			throw new Exception("Unrecognized type.");




		}
    }
}
