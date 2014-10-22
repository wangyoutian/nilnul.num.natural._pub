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
	public class PositiveNatural3:
		
		PositiveNaturalI
	{

		/// <summary>
		/// 
		/// </summary>
		private Natural2 _val;

		public Natural2 val {
			get {
				return _val;
			}
			set {
				_val = value;
			}
		} 

		public PositiveNatural3(Natural2 val)
		{
			//check the val 

			if (IsZero.Eval((NaturalI)val))
			{
				throw new Exception("This is 0.");
			}

			this._val = val;

		}


		public PositiveNatural3(int val)
			:this(new BigInteger(val))
		{
		}
					

		public PositiveNatural3(BigInteger val)
			:this(new Natural2(val) )
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
