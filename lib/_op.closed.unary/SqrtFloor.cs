using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace nilnul.num.natural
{
	static public partial class SqrtFloorX
	{


        static public Natural SqrtFloor(Natural n) {


			if (n==0)
			{
				return new Natural(0);
				
			}
			return new natural.Count(_SqrtFloor(n.val));


        
        }

	

		static public BigInteger _SqrtFloor(this BigInteger _positive) {
			//truncate half.


            var x = LgX.Lb(_positive);

			var y =  x/ 2; //floor of the number.

			
			var candidate = PowX.Pow(2, y);

			while (candidate * candidate <= _positive) {
				candidate++;

			}
			
			return candidate-1;



		
		}

		static public Natural SqrtFloor(this uint i)
		{
			return SqrtFloor(new Natural(i));


		}

		static public Natural SqrtFloor(this long i)
		{
			return SqrtFloor(new Natural(i));


		}

		static public Natural SqrtFloor(this BigInteger i)
		{
			return SqrtFloor(new Natural(i));


		}


		static public Count SqrtFloor(this Plural i)
		{
			return new Count( _SqrtFloor(i.val));


		}

				
	}
}
