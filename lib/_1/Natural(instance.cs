using System;
using System.Net;

using System.Numerics;

namespace nilnul.num.natural._1
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Note: by inherit UintegerI, this is the same as Box(theBoxed) as Uinteger , a special case such that it can be dealt with more specificly.</remarks>
	public partial class Natural
        :UintegerI,NaturalI
		,
		IComparable<Natural>
		
	{

		static public Natural Zero = new Natural(0);
		static public Natural One = new Natural(1);


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

		public Natural(BigInteger val)
		{
			this.val = val;	

		}

		public Natural(Natural n)
			:this(n._val)
		{
		}
					
		public Natural(uint val) {
			this.val = val;
		}

		public Natural(int val)
		{
			this.val = val;
		}

        public BigInteger toBigInteger() {
            return this._val;
        }

		static public implicit operator BigInteger(Natural uinteger)
		{
			return uinteger._val;
		}
		static public explicit operator long(Natural uinteger)
		{
			return (long)(uinteger._val);
		}
		static public explicit operator Natural(BigInteger integer)
		{
            return new Natural(integer);
        }


		static public explicit operator Natural(int integer)
		{
			return new Natural(integer);
		}



		public override string ToString()
		{
			return this._val.ToString();
		}

		static public Natural operator /(Natural n,int i){
			return op.DivideX.Divide(n,i);
		
		}

		static public Natural operator *(Natural a, Natural b)
		{
			return new Natural(a.val * b.val);
		}
		static public Natural operator *(Natural a, int b)
		{
			return new Natural(a.val * b);
		}

		static public Natural operator -(Natural a, Natural b)
		{
			return new Natural(a.val - b.val);
		}

		static public Natural operator -(Natural a, int b)
		{
			return new Natural(a.val - b);
		}

		static public Natural operator ++(Natural a)
		{
			a.val++;	//a.val=a.val+1
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

			if (obj == null || ! (obj is Natural))
			{
				return false;
			}

			// TODO: write your implementation of Equals() here
			return this.val == ((Natural)obj).val;
		}

		// override object.GetHashCode
		public override int GetHashCode()
		{
			// TODO: write your implementation of GetHashCode() here
			
			return val.GetHashCode();
		}

		static public bool operator ==(Natural a, Natural b){

			return a.val == b.val;
		
		}

		static public bool operator !=(Natural a, Natural b)
		{

			return  !(a.val == b.val);

		}

		static public bool operator ==(Natural a, int b)
		{

			return a.val == b;

		}

		static public bool operator !=(Natural a, int b)
		{

			return !(a.val == b);

		}




		public NaturalI minimum(System.Collections.Generic.IEnumerable<NaturalI> subsets)
		{
			throw new NotImplementedException();
		}

		public int CompareTo(NaturalI other)
		{
			throw new NotImplementedException();
		}

		

		public int CompareTo(Natural other)
		{
			return this._val.CompareTo(other._val);
		}
	}

}
