using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;


namespace nilnul.num.natural
{
	public static class SqrtX
	{
		public static int Sqrt(this BigInteger i) {

			

			int x=(int) (Math.Floor(BigInteger.Log(i, 2)));


			//search around x
			//decide the direction
			var y = BigInteger.Pow(2, x);
			while (y<i)
			{
				x++;
				y = BigInteger.Pow(2, x);

				if (y > i) { return x-1; }
	
				
			}
		

			while (y > i) {
				x--;
				y = BigInteger.Pow(2, x);
				if (y < i) { return x; }
			
			}
			return x;
		

		
		}

		public static int Sqrt(this Natural i)
		{



			int x = (int)(Math.Floor(BigInteger.Log(i, 2)));


			//search around x
			//decide the direction
			var y = BigInteger.Pow(2, x);
			while (y < i)
			{
				x++;
				y = BigInteger.Pow(2, x);

				if (y > i) { return x - 1; }


			}


			while (y > i)
			{
				x--;
				y = BigInteger.Pow(2, x);
				if (y < i) { return x; }

			}
			return x;



		}

	}
}
