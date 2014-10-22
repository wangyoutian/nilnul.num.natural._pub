using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural.theorems
{
	public partial class Eq
		:rel.Expr
		
	{
		public Eq(op.ExprI a,op.ExprI b)
			:base(rel.Eq.Instance,a,b)
		{

		}

	}
}
