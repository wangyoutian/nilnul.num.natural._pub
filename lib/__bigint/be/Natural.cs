using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.__bigint.be
{
	public partial class Natural
	{
		static public bool Eval(BigInteger bigInt) {

			return bigInt >= 0;
		
		}

		public class Be:nilnul.bit.Be<BigInteger>
		{
			public Be()
				:base(Eval)
			{

			}
			
		}

		public class Asserted:
			nilnul.bit.be.Asserted<BigInteger,Be>
		{
			public Asserted(BigInteger bigInt)
				:base(bigInt)
			{


			}

			public Asserted(Asserted asserted)
				:base(asserted)
			{

			}

			public void half() {
				this.valSetter /= 2;
			
			}

			public Asserted toHalf() {
				var r = new Asserted(this);
				r.half();
				return r;
			}
		}
	}
}
