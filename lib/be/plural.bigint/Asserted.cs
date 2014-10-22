using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.be.plural.bigint
{
	public partial class Asserted
		:nilnul.bit.be.assert.Ed<BigInteger,Plural.BigInt>
	{
		public Asserted(BigInteger val)
			:base(val)
		{

		}

	}
}
