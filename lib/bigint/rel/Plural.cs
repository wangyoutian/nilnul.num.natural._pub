using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.bigint.rel
{
	public partial class Plural
	{
		static public bool Be(
			BigInteger	i
		) {
			return i > 1;

			throw new NotImplementedException();
		}

		public class Adj
			:nilnul.bit.Be<BigInteger>
		{
			public Adj()
				:base(Be)
			{

			}

		}

		public class Asserted
			:nilnul.bit.be.Asserted<BigInteger,Adj>
		{
			public Asserted(BigInteger i)
				:base(i)
			{

			}
			
		}


	}
}
