using System;
using System.Net;
using nilnul.num.natural.relation;


namespace nilnul.num.natural
{
	public partial  class Ceiling
	{

		static private readonly Ceiling _Instance = new Ceiling();
		static public Ceiling Instance
		{
			get
			{
				return _Instance;
			}
		}
		private Ceiling()
		{
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="a"></param>
		/// <param name="unit"></param>
		/// <returns></returns>
		public Natural eval(Natural a,Natural unit) {

			var remainder=a.Modulo(unit);


			if (remainder.Equal(0)	///exception will be thrown if unit==0
				
				) 
			
			{
				return a;
			}
			else
			{
				return a.Add(unit).Subtract(remainder);
			}
 

		
		}

		public uint eval(uint num, uint unit) {
			return (uint)(eval(num.ToUinteger(), unit.ToUinteger()).val);
			
		}

		public int eval(int num,int unit) {
			return eval(num.ToNatural(), unit.ToNatural()).val.ToInt();
		}

		public Natural eval(int num,Natural unit) {
			return eval(num.ToNatural(), unit);
		}
		static public Natural Eval(Natural a,Natural unit) { 

			return Instance.eval(a,unit);
		
		}
		static public uint Eval(uint num,uint unit) {

			return Instance.eval(num, unit);
		
		}

		static public int Eval(int num,int unit) {
			return Instance.eval(num, unit);
		
		}
		static public Natural Eval(int num, Natural unit) {
			return Instance.eval(num, unit);
		}

	}

	static public partial class CeilingX
	{

		static public Natural Ceiling(this Natural num,Natural unit) {
			return natural.Ceiling.Eval(num, unit);
		
		}
		static public uint Ceiling(this uint num, uint step)
		{

			return natural.Ceiling.Eval(num, step);
		}

		static public int Ceiling(this int num, int unit) {
			return natural.Ceiling.Eval(num, unit);
		
		}

		static public Natural Ceiling(this int num, Natural unit)
		{
			return natural.Ceiling.Eval(num, unit);

		}

		static public Natural Ceiling(this Natural num, Count unit){

			var remainder = num.Modulo(unit);

			return num.Add(unit).Subtract(remainder);


			
		}
		

	}
}
