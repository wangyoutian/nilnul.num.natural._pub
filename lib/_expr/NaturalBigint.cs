using System;
using System.Net;

using System.Numerics;

namespace nilnul.num.natural
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Note: by inherit UintegerI, this is the same as Box(theBoxed) as Uinteger , a special case such that it can be dealt with more specificly.</remarks>
	public partial class NaturalBigint
        :NaturalI
	{

		static public NaturalBigint Zero = new NaturalBigint(0);
		private BigInteger _val;

		public BigInteger val
		{
			get { return _val; }
			set {

				if (val.Sign<0)
				{
					throw new ArgumentOutOfRangeException();

				}
				else
				{
					_val = value; 
			
				}
			
			}
		}


		public NaturalBigint(BigInteger val)
		{
			this.val = val;	

		}
		public NaturalBigint(uint val) {
			this.val = val;
		}

		public NaturalBigint(int val)
		{
			this.val = val;
		}

        public BigInteger toBigint() {
            return this._val;
        }

        static public implicit operator BigInteger(NaturalBigint uinteger){
            return uinteger._val;
        }
        static public explicit operator NaturalBigint(BigInteger integer) {
            return new natural.NaturalBigint(integer);
        }

		public override string ToString()
		{
			return this._val.ToString();
		}




		public NaturalI minimum(System.Collections.Generic.IEnumerable<NaturalI> subsets)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(NaturalI other)
		{
			throw new NotImplementedException();
		}
	}

}
