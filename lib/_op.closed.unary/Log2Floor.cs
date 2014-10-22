using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace nilnul.num.natural
{
	public static class Log2FloorX
	{
	


		/// <summary>
		/// 
		/// </summary>
		/// <param name="goal"></param>
		/// <returns></returns>
		/// <remarks>
		/// Will accrue the 2's power
		/// </remarks>

		public static Natural Log2Floor2_byRecurTry(this PositiveNatural2 goal)
		{
			


			//exp will be the upper bound. exp-1 will be the lower bound. the unknown is in (2^exp-1,2^exp]

			return new Natural(_byRecurRecon(2,goal.val.val));


		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="accumulated"></param>
		/// <param name="goal">
		/// 
		/// </param>
		/// <param name="factor"></param>
		/// <returns>
		/// get an index
		/// [0,...)
		/// </returns>
		/// <remarks>
		/// get an x such that accumulated*factor^(2^x) &lt; goal &le; accumlated*factor^(2^(x+1)).
		/// 
		/// increase the accumulated one time and again.
		/// </remarks>
		private static BigInteger _byRecurRecon(BigInteger @base_positive,BigInteger goal_positive ) {
			
			BigInteger index = 0;
			BigInteger accumulated=1;



			BigInteger indexOf2InIndexOfForward;	//x in forward=factor^(2^x)
			BigInteger forward;
			BigInteger forwardIndex;

			BigInteger recon;


			do
			{
				//init forward
				indexOf2InIndexOfForward = 0;
				forwardIndex = 1;
				forward =@base_positive;

				// init recon
				recon = accumulated*forward;
		
				while (recon <= goal_positive)
				{
					//update index
					index = index + forwardIndex;
					accumulated = recon;


					//update forward

					indexOf2InIndexOfForward = indexOf2InIndexOfForward + 1;
					forwardIndex = forwardIndex * 2;
					forward = forward * forward;

					//update recon
					recon = accumulated * forward;
				}//overreach, now backtrack


			} while (indexOf2InIndexOfForward != 0);
			

			return index;

		}


		public static int Log2Floor(this BigInteger i)
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
