using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N=nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.expr
{
	public partial class Abstract
		:
		nilnul.obj.expr.Abstract<N,N>
	{
		public Abstract(VarI var, ExprI1 expr )
			:base(var,expr)
			
		{

		}
	}
}
