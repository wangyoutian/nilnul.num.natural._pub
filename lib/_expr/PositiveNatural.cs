using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural
{
	/// <summary>
	/// the stored structure is UintegerI, and with some constraints.
	/// </summary>
	public class PositiveNatural : PositiveNaturalI
	{

		/// <summary>
		/// 
		/// </summary>
		private NaturalI _val;

		public NaturalI val {
			get {
				return _val;
			}
			set {
				_val = value;
			}
		} 

		public PositiveNatural(NaturalI val)
		{
			//check the val 

			if (IsZero.Eval(val))
			{
				throw new Exception("This is 0.");
			}

			this._val = val;

		}


		public PositiveNatural(int val)
			:this(new BigInteger(val))
		{
		}
					

		public PositiveNatural(BigInteger val)
			:this(new NaturalBigint(val) as NaturalI)
		{
			

		}

		public NaturalI toNatural()
		{
			return _val;

		}

		public BigInteger toBigint()
		{
			return _val.ToBigint();
		}


		public override string ToString()
		{
			return this._val.ToString();
		}



		public NaturalI minimum(IEnumerable<NaturalI> subsets)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(NaturalI other)
		{
			throw new NotImplementedException();
		}
	}
}
