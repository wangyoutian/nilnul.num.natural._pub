using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Numerics;

namespace nilnul.num.natural
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Note: by inherit UintegerI, this is the same as Box(theBoxed) as Uinteger , a special case such that it can be dealt with more specificly.</remarks>
	public partial class Natural_bigInteger
        :UintegerI,NaturalI
		,
		IComparable<Natural_bigInteger>
		,
		IEquatable<Natural_bigInteger>
		
	{
		public const char Symbol_N = 'ℕ';	//0x2115;
		

		static public readonly Natural_bigInteger Zero = new Natural_bigInteger(0);
		static public readonly Natural_bigInteger One = new Natural_bigInteger(1);

		static public Natural_bigInteger GetZero {

			get {
				return new Natural_bigInteger(0);
			}
		
		}

		static public Natural_bigInteger NewOne
		{

			get
			{
				return new Natural_bigInteger(1);
			}

		}


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

		public Natural_bigInteger(BigInteger val)
		{
			this.val = val;	

		}

		public Natural_bigInteger(Natural_bigInteger n)
			:this(n._val)
		{
		}
					
		public Natural_bigInteger(uint val) {
			this.val = val;
		}

		public Natural_bigInteger(int val)
		{
			this.val = val;
		}

        public BigInteger toBigInteger() {
            return this._val;
        }

		static public implicit operator BigInteger(Natural_bigInteger uinteger)
		{
			return uinteger._val;
		}
		static public implicit operator Natural_bigInteger(uint uinteger)
		{
			return new Natural_bigInteger(uinteger);
		}
		static public explicit operator long(Natural_bigInteger uinteger)
		{
			return (long)(uinteger._val);
		}
		static public explicit operator Natural_bigInteger(BigInteger integer)
		{
            return new Natural_bigInteger(integer);
        }


		static public explicit operator Natural_bigInteger(int integer)
		{
			return new Natural_bigInteger(integer);
		}



		public override string ToString()
		{
			return this._val.ToString();
		}

		

		static public Natural_bigInteger operator /(Natural_bigInteger n,Natural_bigInteger i){

			return new Natural_bigInteger( n.val/i.val);
		
		}

		static public Natural_bigInteger operator /(Natural_bigInteger n, int i)
		{

			return n/new Natural_bigInteger(i);

		}

		static public Natural_bigInteger operator *(Natural_bigInteger a, Natural_bigInteger b)
		{
			return new Natural_bigInteger(a.val * b.val);
		}
		static public Natural_bigInteger operator *(Natural_bigInteger a, int b)
		{
			return new Natural_bigInteger(a.val * b);
		}

		static public Natural_bigInteger operator -(Natural_bigInteger a, Natural_bigInteger b)
		{
			return new Natural_bigInteger(a.val - b.val);
		}

		static public Natural_bigInteger operator -(Natural_bigInteger a, int b)
		{
			return new Natural_bigInteger(a.val - b);
		}
		static public Natural_bigInteger operator +(Natural_bigInteger a, int b)
		{
			return new Natural_bigInteger(a.val + b);
		}

		static public Natural_bigInteger Add(Natural_bigInteger a, Natural_bigInteger b)
		{
			return new Natural_bigInteger(a.val + b.val);
		}
		static public Natural_bigInteger operator +(Natural_bigInteger a, Natural_bigInteger b)
		{
			return new Natural_bigInteger(a.val + b.val);
		}

		static public Natural_bigInteger operator ++(Natural_bigInteger a)
		{
			a.val++;	//a.val=a.val+1
			return a;
			//return new Natural(a.val+1);
		}

		static public Natural_bigInteger operator --(Natural_bigInteger a)
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

			if (obj == null || ! (obj is Natural_bigInteger))
			{
				return false;
			}

			// TODO: write your implementation of Equals() here
			return this.val == ((Natural_bigInteger)obj).val;
		}

		// override object.GetHashCode
		public override int GetHashCode()
		{
			// TODO: write your implementation of GetHashCode() here
			
			return val.GetHashCode();
		}

		static public bool Equals(Natural_bigInteger a,Natural_bigInteger b) {
			return a.val == b.val;
		
		}

		static public bool operator ==(Natural_bigInteger a, Natural_bigInteger b){

			return a.val == b.val;
		
		}

		static public bool operator !=(Natural_bigInteger a, Natural_bigInteger b)
		{

			return  !(a.val == b.val);

		}

		static public bool operator ==(Natural_bigInteger a, int b)
		{

			return a.val == b;

		}

		static public bool operator !=(Natural_bigInteger a, int b)
		{

			return !(a.val == b);

		}


		static public bool operator >(Natural_bigInteger a, Natural_bigInteger b)
		{

			return a.val>b.val;

		}

		static public bool operator >(Natural_bigInteger a, int b)
		{

			return a.val > b;

		}

	

		static public bool operator >=(Natural_bigInteger a, Natural_bigInteger b)
		{

			return a.val >= b.val;

		}
		static public bool operator >=(Natural_bigInteger a, int b)
		{

			return a.val >= b;

		}

		static public bool operator <(Natural_bigInteger a, Natural_bigInteger b)
		{

			return a.val < b.val;

		}
		static public bool operator <(Natural_bigInteger a, int b)
		{

			return a.val < b;

		}
		static public bool operator <=(Natural_bigInteger a, Natural_bigInteger b)
		{

			return a.val <= b.val;

		}
		static public bool operator <=(Natural_bigInteger a, int b)
		{

			return a.val <= b;

		}




	

		

		public int CompareTo(Natural_bigInteger other)
		{
			return this._val.CompareTo(other._val);
		}

		public bool Equals(Natural_bigInteger other)
		{
			return this.val==other.val;
		}

		public class Eq
			:IEqualityComparer<Natural_bigInteger>
		{

			public bool Equals(Natural_bigInteger x, Natural_bigInteger y)
			{
				return x.val==y.val;
			}

			public int GetHashCode(Natural_bigInteger obj)
			{
				return obj.val.GetHashCode();
				throw new NotImplementedException();
			}
		}
	}

}
