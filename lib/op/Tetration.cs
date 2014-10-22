using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural.op
{
	public partial class Tetration
	{
		public static Natural_bigInteger Eval(Natural_bigInteger a, Natural_bigInteger b) {
			Natural_bigInteger r =new Natural_bigInteger( 1);
			while (b>0)
			{
				r = nilnul.num.natural.op.PowX2.Eval(a, r);
				b--;
				
			}
			return r;
			throw new NotImplementedException();
		
		}

		public static Natural_bigInteger Eval(int a, int b) {

			return Eval(new Natural_bigInteger(a),new Natural_bigInteger(b));
		
		}


	}
}
