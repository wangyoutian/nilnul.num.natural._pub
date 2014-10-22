using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural.op
{
	public partial class Pentation
	{
		public static Natural_bigInteger Eval(Natural_bigInteger a,Natural_bigInteger b) {

			var r = Natural_bigInteger.NewOne;

			while (b>0)
			{
				r = op.Tetration.Eval(a, r);
				b--;
				
			}
			return r;
		
		}
	}
}
