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
	public class PositiveNatural_inheritNatural2
		:
		Natural_bigInteger
		,
	
		PositiveNaturalI
		,
		IEquatable<PositiveNatural_inheritNatural2>
	{


		static public PositiveNatural_inheritNatural2 Add(PositiveNatural_inheritNatural2 a,PositiveNatural_inheritNatural2 b) {

			return new PositiveNatural_inheritNatural2(a.val + b.val);
		
		}

		static public PositiveNatural_inheritNatural2 Add(PositiveNatural_inheritNatural2 a, int b)
		{

			return Add(a,new PositiveNatural_inheritNatural2(b));

		}

		static public  PositiveNatural_inheritNatural2  operator +(PositiveNatural_inheritNatural2 a,PositiveNatural_inheritNatural2 b){
			return Add(a, b);
		
		}

		static public PositiveNatural_inheritNatural2 operator +(PositiveNatural_inheritNatural2 a, int b)
		{
			return Add(a, new PositiveNatural_inheritNatural2( b));

		}

	

		public PositiveNatural_inheritNatural2()
			:base(1)
		{
		}
					
		

		public PositiveNatural_inheritNatural2(Natural2 val)
			:base(val.val)
		{
			//check the val 

			nilnul.bit.AssertX.True(val.val > 0);

		

		}


		public PositiveNatural_inheritNatural2(int val)
			:this(new BigInteger(val))
		{
		}
					

		public PositiveNatural_inheritNatural2(BigInteger val)
			:base(val)
		{
			_assert();

		}

		private void _assert() {
			nilnul.bit.AssertX.True(val > 0);
		}

		public NaturalI toNatural()
		{
			return this;

		}

		public BigInteger toBigint()
		{
			return val;
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

		static public bool GreaterThan(PositiveNatural_inheritNatural2 a, PositiveNatural_inheritNatural2 b)
		{
			return a.val > b.val;
		}
		static public bool LessThan(PositiveNatural_inheritNatural2 a, PositiveNatural_inheritNatural2 b)
		{
			return a.val < b.val;
		}

		static public  bool operator >(PositiveNatural_inheritNatural2 a, PositiveNatural_inheritNatural2 b)
		{

			return GreaterThan(a, b);

		}

		static public  bool operator >(PositiveNatural_inheritNatural2 a, int b)
		{

			return GreaterThan(a,new PositiveNatural_inheritNatural2(  b));

		}

		static public bool operator <(PositiveNatural_inheritNatural2 a, int b)
		{

			return LessThan(a, new PositiveNatural_inheritNatural2(b));

		}
		static public  bool operator <(PositiveNatural_inheritNatural2 a, PositiveNatural_inheritNatural2 b)
		{

			return LessThan(a, b);

		}

		static public bool Equals(PositiveNatural_inheritNatural2 a, PositiveNatural_inheritNatural2 b){

			return Natural2.Equals(a,b);
		
		}

		static public bool operator ==(PositiveNatural_inheritNatural2 a, PositiveNatural_inheritNatural2 b)
		{

			return Equals(a, b);

		}

		static public bool operator !=(PositiveNatural_inheritNatural2 a, PositiveNatural_inheritNatural2 b)
		{

			return !Equals(a, b);

		}


		public bool Equals(PositiveNatural_inheritNatural2 other)
		{
			return Equals(this,other);
		}
	}
}
