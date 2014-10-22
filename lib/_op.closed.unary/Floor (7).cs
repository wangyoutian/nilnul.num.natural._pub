using System;
using System.Net;


namespace nilnul.num.natural
{
	public partial class Floor
	{

		static private readonly Floor _Instance = new Floor();
		static public Floor Instance
		{
			get
			{
				return _Instance;
			}
		}
		private Floor()
		{
		}

		public Natural eval(Natural dividend,Natural unit) {
			return dividend.Subtract( dividend.Modulo(unit));
		}

		static public Natural Eval(Natural dividend,Natural unit) {
			return Instance.eval(dividend, unit);
		}
				

	}

	static public partial class FloorX
	{
		static public Natural Floor(Natural dividend,Natural unit) {
			return natural.Floor.Eval(dividend, unit);
		}
		
	}
}
