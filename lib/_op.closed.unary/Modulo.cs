using System;
using System.Net;
using nilnul.num.natural;
using nilnul.num.natural.relation;



namespace nilnul.num.natural
{
	public partial class Modulo
	{

		static private readonly Modulo _Instance = new Modulo();
		static public Modulo Instance
		{
			get
			{
				return _Instance;
			}
		}
		private Modulo()
		{
		}

		public Natural eval(Natural dividend,Natural divisor) {

			if (divisor.Equal(Natural.Zero))
			{
				throw new Exception();
			}
			else
			{
				return (dividend.val % divisor.val).ToNatural();
			}
		}

		public Natural eval(int dividend,Natural divisor) {

			return eval(dividend.ToNatural(), divisor);
		
		}

		static public Natural Eval(Natural dividend,Natural divisor) {

			return Instance.eval(dividend, divisor);
		
		}

		static public Natural Eval(int dividend,Natural divisor) {
			return Instance.eval(dividend, divisor);
		}
				

	}

	static public partial class ModuloX {
		static public Natural Modulo(this Natural dividend, Natural divisor) {
			return natural.Modulo.Eval(dividend, divisor);
		}
		static public Natural Modulo(this int dividend,Natural divisor) {
			return natural.Modulo.Eval(dividend, divisor);
		
		}

		
	}
}
