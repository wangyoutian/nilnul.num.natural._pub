using System;
using System.Net;
using System.Numerics;


namespace nilnul.num.natural
{
	public partial class PositiveIntegerByBigInteger
		:Natural,PositiveIntegerI
	{
		//public BigInteger val;


		public PositiveIntegerByBigInteger(BigInteger a):base(a)
		{

			///


			if (a<=0)
			{
				throw new ArgumentOutOfRangeException();
				
			}
			this.val = a;
		}

		public static PositiveIntegerByBigInteger ToPositiveInt(int a) {
			return new PositiveIntegerByBigInteger(a);
		
		}
		public override string ToString()
		{
			return base.ToString();
		}
					

	}

	
}
