using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.be
{
	public partial class Plural
	{
		static public bool Be(BigInteger i) {
			return i > 1;

			throw new NotImplementedException();
		
		}
		static public bool Eval(BigInteger i) {
			return i > 1;

			throw new NotImplementedException();
		
		}


		public class BigInt
			:nilnul.bit.Be<BigInteger>
		{
			public BigInt()
				:base(Be)
			{

			}

	

			public class Suite
				:nilnul.bit.be.assert.ed.Suite<BigInteger,BigInt>
			{
				
				
			}


		}

		public class Be1
			:nilnul.bit.Be<BigInteger>
		{
			public Be1()
				:base(Eval)
			{

			}
		}

		public class Expr__bigInt:
			nilnul.bit.be.Asserted<BigInteger,Be1>
		{
			public Expr__bigInt(BigInteger x)
				:base(x)
			{

			}



		}

	}
}
