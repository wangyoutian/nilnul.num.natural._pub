using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Natural1 = nilnul.num.natural._1.Natural;

namespace nilnul.num.natural.op
{
	static public partial class DivideX
	{
		public static Natural Eval(Natural n,Count divisor)
		{

			return new Natural(n.val / divisor.val);
		}

		static public num.natural.Natural_bigInteger Half(this Natural_bigInteger x)
		{

			return Eval(x, 2);


		}
		static public num.natural.Natural_bigInteger Half(this BigInteger x)
		{

			return Eval(x, 2);


		}

		static public num.natural.__bigint.be.Natural.Asserted Half(this num.natural.__bigint.be.Natural.Asserted x)
		{

			return x.toHalf();


		}

	static public num.natural.Natural_bigInteger Eval(Natural_bigInteger dividend, be.Positive.Expr__bigInt divisor)
		{

			return new Natural_bigInteger(dividend.val / divisor.val);

		}
		static public num.natural.Natural_bigInteger Eval(Natural_bigInteger dividend, int divisor_positive)
		{

			return new Natural_bigInteger(dividend.val / divisor_positive);

		}

		static public num.natural.Natural_bigInteger Eval(BigInteger dividend_natural, int divisor_positive)
		{

			return new Natural_bigInteger(dividend_natural / divisor_positive);

		}

		public static Natural Eval(Natural n,int divisor)
		{

			return Eval(n,new Count(divisor));
		}

		public static Natural1 Divide(this Natural1 dividend, Count divisor) {

			return new Natural1(dividend.val / divisor.val);
		
		}

		public static Natural2 Divide(this Natural2 dividend, Count divisor)
		{

			return new Natural2(dividend.val / divisor.val);

		}

		public static Natural2 Divide(this Natural2 dividend, int divisor)
		{

			return Divide(dividend,new Count(divisor));

		}



		public static Natural1 Divide(this Natural1 dividend, int divisor)
		{

			return new Natural1(dividend.val / new Count(divisor).val);

		}




	}
}
