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
	public class PositiveNatural_inheritNatural
		:
		Natural2
		,
	
		PositiveNaturalI
		,
		IEquatable<PositiveNatural_inheritNatural>
	{


		static public PositiveNatural_inheritNatural Add(PositiveNatural_inheritNatural a,PositiveNatural_inheritNatural b) {

			return new PositiveNatural_inheritNatural(a.val + b.val);
		
		}

		static public PositiveNatural_inheritNatural Add(PositiveNatural_inheritNatural a, int b)
		{

			return Add(a,new PositiveNatural_inheritNatural(b));

		}

		static public  PositiveNatural_inheritNatural  operator +(PositiveNatural_inheritNatural a,PositiveNatural_inheritNatural b){
			return Add(a, b);
		
		}

		static public PositiveNatural_inheritNatural operator +(PositiveNatural_inheritNatural a, int b)
		{
			return Add(a, new PositiveNatural_inheritNatural( b));

		}

	

		public PositiveNatural_inheritNatural()
			:base(1)
		{
		}
					
		

		public PositiveNatural_inheritNatural(Natural2 val)
			:base(val.val)
		{
			//check the val 

			nilnul.bit.AssertX.True(val.val > 0);

		

		}


		public PositiveNatural_inheritNatural(int val)
			:this(new BigInteger(val))
		{
		}
					

		public PositiveNatural_inheritNatural(BigInteger val)
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

		static public bool GreaterThan(PositiveNatural_inheritNatural a, PositiveNatural_inheritNatural b)
		{
			return a.val > b.val;
		}
		static public bool LessThan(PositiveNatural_inheritNatural a, PositiveNatural_inheritNatural b)
		{
			return a.val < b.val;
		}

		static public  bool operator >(PositiveNatural_inheritNatural a, PositiveNatural_inheritNatural b)
		{

			return GreaterThan(a, b);

		}

		static public  bool operator >(PositiveNatural_inheritNatural a, int b)
		{

			return GreaterThan(a,new PositiveNatural_inheritNatural(  b));

		}

		static public bool operator <(PositiveNatural_inheritNatural a, int b)
		{

			return LessThan(a, new PositiveNatural_inheritNatural(b));

		}
		static public  bool operator <(PositiveNatural_inheritNatural a, PositiveNatural_inheritNatural b)
		{

			return LessThan(a, b);

		}

		static public bool Equals(PositiveNatural_inheritNatural a, PositiveNatural_inheritNatural b){

			return Natural2.Equals(a,b);
		
		}

		static public bool operator ==(PositiveNatural_inheritNatural a, PositiveNatural_inheritNatural b)
		{

			return Equals(a, b);

		}

		static public bool operator !=(PositiveNatural_inheritNatural a, PositiveNatural_inheritNatural b)
		{

			return !Equals(a, b);

		}


		public bool Equals(PositiveNatural_inheritNatural other)
		{
			return Equals(this,other);
		}
	}
}
