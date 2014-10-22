using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.op
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 140614
	/// </remarks>
	public partial class Sum
		
	{
		static public N Eval(IEnumerable<N> terms) {

			return terms.Aggregate(N.GetZero, (c, w) => c + w);
		
		}

	
	

	

		
	}
}
