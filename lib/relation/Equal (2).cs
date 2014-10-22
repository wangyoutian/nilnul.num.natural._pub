using System;
using System.Net;
using System.Numerics;



namespace nilnul.num.natural.relation
{
	public partial class Equal
	{

		static private readonly Equal _Instance = new Equal();
		static public Equal Instance
		{
			get
			{
				return _Instance;
			}
		}
		private Equal()
		{
		}
		public bool eval(Natural a,Natural b
			
			) {

				if (a.val==b.val)
				{
					return true;

				}
				else
				{
					return false;
				}
		
		}
		public bool eval(Natural a,uint b) { 
			return eval(a,b.ToUinteger());
		
		}

		public bool eval(Natural a, int b)
		{
			return eval(a, b.ToNatural());

		}

		static public bool Eval(Natural a,Natural b) {

			return Instance.eval(a, b);
		
		}

		static public bool Eval(Natural a,uint b) {
			return Instance.eval(a, b);

		
		
		}

		static public bool Eval(Natural a, int b)
		{
			return Instance.eval(a, b);



		}

		static public bool Eval(Infinite a, uint b ) {
			return false;
		
		}

		static public bool Eval(uint b,Infinite a )
		{
			return false;

		}

		static public bool Eval(uint b, ExtendedNaturalI a)
		{
			return false;

		}
				

	}
	static public partial class EqualX
	{
		static public bool Equal(this Natural a,Natural b) {
			return natural.relation.Equal.Eval(a, b);
		}
		static public bool Equal(this Natural a, uint b) {
			return natural.relation.Equal.Eval(a, b);
		}

		static public bool Equal(this Natural a, int b)
		{
			return natural.relation.Equal.Eval(a, b);
		}

		static public void Assert(Natural a, Natural b) {
			nilnul.bit.AssertX.Equals(a.val, b.val);
		
		}

		//static public void Assert(BigInteger a, BigInteger b)
		//{
		//	nilnul.bit.AssertX.Equals(a, b);

		//}

		
	}
}
