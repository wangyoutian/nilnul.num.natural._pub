using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;
namespace nilnul.num.natural.theorems
{
	public partial class BinomialEquation
		:Eq
	{
		private Var _a=new Var();

		public Var a
		{
			get { return _a; }
			private set { _a = value; }
		}

		private Var _b=new Var();

		public Var b
		{
			get { return _b; }
			private set { _b = value; }
		}

		private Var _n=new Var();

		public Var n
		{
			get { return _n=new Var(); }
			//set { _n=new Var() = value; }
		}

		private Var _i;

		public Var i
		{
			get { return _i; }
			set { _i = value; }
		}
		
		
		
		

		public BinomialEquation()
			:base(
				null
				,


			null
				
				
			)
		{

			this.arg=nilnul.num.natural.op.Pow.Call(
					nilnul.num.natural.op.Add1.Call(a,b)
					,
					n
			);
			this.arg1 =
				nilnul.num.natural.op.Sigma.Eval(
					new Literal(0u)
					,
					n
					,
					new nilnul.obj.expr.Abstract<N,N>(
						i,
						nilnul.num.natural.op.Pow.Call(a,i)
							
					)
				
				
			);
				nilnul.num.natural.op.Add1.Call(new Var(), new Var());


		}

	}
}
