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
	public class PositiveNatural2 : PositiveNaturalI
	{

		/// <summary>
		/// 
		/// </summary>
		private Natural _val;

		public Natural val {
			get {
				return _val;
			}
			set {
				_val = value;
			}
		} 

		public PositiveNatural2(Natural val)
		{
			//check the val 

			if (IsZero.Eval((NaturalI)val))
			{
				throw new Exception("This is 0.");
			}

			this._val = val;

		}


		public PositiveNatural2(int val)
			:this(new BigInteger(val))
		{
		}
					

		public PositiveNatural2(BigInteger val)
			:this(new Natural(val) )
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
