using System;
using System.Net;
using System.Numerics;

namespace nilnul.num.natural
{
	public partial class Add
	{

		static private readonly Add _Instance = new Add();
		static public Add Instance
		{
			get
			{
				return _Instance;
			}
		}
		private Add()
		{
		}

		public Natural eval(Natural a,Natural b) {

			return (a.val + b.val).ToNatural();
		
		}

		static public Natural Eval(Natural a,Natural b) {
			return Instance.eval(a, b);
		}

		static public BigInteger Eval(Natural a,BigInteger b) {
				return a.toBigInteger()+b;
		}





		
				

	}

	static public partial class AddX
	{
		
		static public BigInteger Add(this Natural a, BigInteger b)
		{
			return natural.Add.Eval(a, b);

		}

		static public Natural Add(this Natural a, Natural b)
		{
			return new Natural(a.val+b.val);

		}

		static public Count Add(this Natural a, Count b)
		{
			return new Count(a.val + b.val);

		}


		static public PositiveNatural2 Add(this Natural a, PositiveNatural2 b)
		{
			return new PositiveNatural2(Add(a,b.val));

		}

		
		
	}
}
