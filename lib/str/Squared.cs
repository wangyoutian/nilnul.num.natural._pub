using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.str
{
	public partial class Squared
	{
		static public BigInteger _Sum(BigInteger n_natural) {
			return n_natural * (n_natural + 1) * (2 * n_natural + 1) / 6;
		}
	}
}
