using System;
using System.Net;


namespace nilnul.num.natural
{
	public partial class Subtract
	{

		static private readonly Subtract _Instance = new Subtract();
		static public Subtract Instance
		{
			get
			{
				return _Instance;
			}
		}
		private Subtract()
		{
		}
		public Natural eval(Natural a,Natural b) {
			
				return (a.val - b.val).ToNatural();
			
		}
		public Natural eval(Natural a,int b) {
			return eval(a, b.ToNatural());
		}

		static public Natural Eval(Natural a,Natural b) {

			return Instance.eval(a, b);
		
		}
		static public Natural Eval(Natural a,int b) {
			return Instance.eval(a, b);
		
		}

	}

	static public partial class SubtractX {
		static public Natural Subtract(this Natural a,Natural b) {

			return  natural.Subtract.Eval(a, b);
		
		}
		static public Natural Subtract(this Natural a, int b) {

			return natural.Subtract.Eval(a, b);
		
		}
	}
}
