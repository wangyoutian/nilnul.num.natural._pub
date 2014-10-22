using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.__bigint.be
{
	public partial class Positive
	{
		static public bool Eval(BigInteger x) {
			return x > 0;
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
			public Asserted(BigInteger x)
				:base(x)
			{

			}

			public bool isEven() {
				return val.IsEven;
			}

		}
	}
}
