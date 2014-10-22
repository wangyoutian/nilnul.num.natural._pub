using System;
using System.Net;

using System.Numerics;

namespace nilnul.num.natural
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Note: by inherit UintegerI, this is the same as Box(theBoxed) as Uinteger , a special case such that it can be dealt with more specificly.</remarks>
	public partial class Natural2
        :UintegerI,NaturalI
		,
		IComparable<Natural2>
		,
		IEquatable<Natural2>
		
	{

		static public Natural2 Zero = new Natural2(0);
		static public Natural2 One = new Natural2(1);


		protected BigInteger _val;

		public virtual BigInteger val
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

		public Natural2(BigInteger val)
		{
			this.val = val;	

		}

		public Natural2(Natural2 n)
			:this(n._val)
		{
		}
					
		public Natural2(uint val) {
			this.val = val;
		}

		public Natural2(int val)
		{
			this.val = val;
		}

        public BigInteger toBigInteger() {
            return this._val;
        }

		static public implicit operator BigInteger(Natural2 uinteger)
		{
			return uinteger._val;
		}
		static public explicit operator long(Natural2 uinteger)
		{
			return (long)(uinteger._val);
		}
		static public explicit operator Natural2(BigInteger integer)
		{
            return new Natural2(integer);
        }


		static public explicit operator Natural2(int integer)
		{
			return new Natural2(integer);
		}



		public override string ToString()
		{
			return this._val.ToString();
		}

		static public Natural2 operator /(Natural2 n,int i){
			return op.DivideX.Divide(n,i);
		
		}

		static public Natural2 operator *(Natural2 a, Natural2 b)
		{
			return new Natural2(a.val * b.val);
		}
		static public Natural2 operator *(Natural2 a, int b)
		{
			return new Natural2(a.val * b);
		}

		static public Natural2 operator -(Natural2 a, Natural2 b)
		{
			return new Natural2(a.val - b.val);
		}

		static public Natural2 operator -(Natural2 a, int b)
		{
			return new Natural2(a.val - b);
		}

		static public Natural2 operator ++(Natural2 a)
		{
			a.val++;	//a.val=a.val+1
			return a;
			//return new Natural(a.val+1);
		}

		static public Natural2 operator --(Natural2 a)
		{
			a.val--;	//a.val=a.val+1
			return a;
			//return new Natural(a.val+1);
		}


		// override object.Equals
		public override bool Equals(object obj)
		{
			//       
			// See the full list of guidelines at
			//   http://go.microsoft.com/fwlink/?LinkID=85237  
			// and also the guidance for operator== at
			//   http://go.microsoft.com/fwlink/?LinkId=85238
			//

			if (obj == null || ! (obj is Natural2))
			{
				return false;
			}

			// TODO: write your implementation of Equals() here
			return this.val == ((Natural2)obj).val;
		}

		// override object.GetHashCode
		public override int GetHashCode()
		{
			// TODO: write your implementation of GetHashCode() here
			
			return val.GetHashCode();
		}

		static public bool operator ==(Natural2 a, Natural2 b){

			return a.val == b.val;
		
		}

		static public bool operator !=(Natural2 a, Natural2 b)
		{

			return  !(a.val == b.val);

		}

		static public bool operator ==(Natural2 a, int b)
		{

			return a.val == b;

		}

		static public bool operator !=(Natural2 a, int b)
		{

			return !(a.val == b);

		}




	

		

		public int CompareTo(Natural2 other)
		{
			return this._val.CompareTo(other._val);
		}

		public bool Equals(Natural2 other)
		{
			return this.val==other.val;
		}
	}

}
