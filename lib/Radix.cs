using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural
{
	public partial class Radix
	{
		private SortedSet<char> _digits;
		public SortedSet<char> digits
		{
			get { return _digits; }
			set {
				_digits = value; 
			}
		}

		public void set(
			SortedSet<char> digits	
		) {
			nilnul.bit.Assertion.True(digits.Count > 0);
			_digits = digits;
		
		}
		public Radix(SortedSet<char> digits)
		{
			set(digits);
			

		}

		static public Radix Create(int _2to17_) {
			return new Radix(new SortedSet<char>(Hex_Chars.Substring(0,_2to17_)));
		}

		static public Radix Create(BigInteger _2to17_)
		{
			return new Radix(new SortedSet<char>(Hex_Chars.Substring(0, (int)_2to17_)));
		}


		private class Private
		{
			public SortedSet<char> _digits;

			public SortedSet<char> digits
			{
				get { return _digits; }
				set { _digits = value; }
			}
			

			
		}

		private Radix(
			Private private_
		)
		{
			this._digits = private_._digits;
		}


		public int count
		{
			get
			{
				return _digits.Count;
			}
		}

		static public SortedSet<char> HexChars{
			get {
				return new SortedSet<char>(Hex_Chars);
			}
		
		}

		static public SortedSet<char> DecChars {
			get {
				return new SortedSet<char>(Dec_Chars);
			}
		}

		static public SortedSet<char> OctChars {
			get {
				return new SortedSet<char>(Oct_Chars);
			}
		}

		static public SortedSet<char> BiChars {
			get {
				return new SortedSet<char>(Bi_Chars);
			}
		}


		public const string Hex_Chars = "0123456789ABCDEF";

		public static string Dec_Chars = Hex_Chars.Substring(0, 10);
		public static string Oct_Chars = Hex_Chars.Substring(0, 8);
		public static string Bi_Chars = Hex_Chars.Substring(0, 2);
		public class Hex
			:Radix
		{
			public Hex()
				:base(HexChars)
			{

			}

			public class Singleton
				:SingletonByDefaultNew<Hex>
			{
				
			}
			
		}

		public class Decimal
			:Radix
		{
			public Decimal()
				:base(DecChars)
			{

			}

			public class Singleton
				:SingletonByDefaultNew<Decimal>
			{
				
			}
			
		}

		public class Oct
			:Radix
		{
			public Oct()
				:base(OctChars)
			{

			}
			public class Singleton
				:SingletonByDefaultNew<Oct>
			{
				
			}
			
		}

		public class Binary
			:Radix
		{
			public Binary():base(BiChars)
			{

			}

			public class Singleton
				:SingletonByDefaultNew<Binary>
			{
				
			}

		}






		
	}
}
