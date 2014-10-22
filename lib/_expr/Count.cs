using System;
using System.Net;

using System.Numerics;

namespace nilnul.num.natural
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Note: by inherit UintegerI, this is the same as Box(theBoxed) as Uinteger , a special case such that it can be dealt with more specificly.</remarks>
	public partial class Count
        :Natural
	{

		static public Count One = new Count(1);


		public override BigInteger val
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


		public void increase() {
			_val++;
		}

		public Count(BigInteger val)
			:base(val)
		{
			this.val = val;	

		}
		public Count(uint val):base(val) {
			this.val = val;
		}

		public Count(int val):base(val)
		{
			this.val = val;
		}

        public BigInteger toBigInteger() {
            return this._val;
        }

        static public implicit operator BigInteger(Count uinteger){
            return uinteger._val;
        }
        static public explicit operator Count(BigInteger integer) {
            return new natural.Count(integer);
        }

		static public  Count operator *(Count a,Count b){

			return new Count(a._val * b._val);
		
		} 

		public override string ToString()
		{
			return this._val.ToString();
		}

		
        
	}

}
