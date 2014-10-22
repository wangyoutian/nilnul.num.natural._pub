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
	public partial class Sigma
		
	{
		static public N Eval(N initial, N endInclusive, Func<N,N> func) {
			N r = 0u;
			for (N i = initial; i <= endInclusive; i++)
			{
				r += func(i);
				
			}
			return r;
		
		}

		//static public ExprI Eval(ExprI initial, ExprI endInclusive, Func<Var, ExprI> func)
		//{
		//	return new Expr(initial, endInclusive, func);


		//}
		static public ExprI Eval(ExprI initial, ExprI endInclusive, nilnul.obj.expr.Abstract<N, N> func)
		{
			return  new  Expr(initial, endInclusive, func);


		}
		//static public ExprI Eval(ExprI initial, ExprI endInclusive, Func<Var, ExprI> func)
		//{
		//	return new Expr(initial, endInclusive, func);


		//}

		 public class Expr
			:ExprI
		{

			ExprI initial;
			ExprI endInclusive;

			nilnul.obj.expr.Abstract<N, N> func;

			public Expr(ExprI initial,ExprI endInclusive, nilnul.obj.expr.Abstract<N, N> func)
			{
				this.initial = initial;
				this.endInclusive = endInclusive;
				this.func = func;

			}
			
		}

	

		
	}
}
