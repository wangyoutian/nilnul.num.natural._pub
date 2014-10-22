using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{
	public class HexDigits__ByList
	{
		static public readonly string digits = "0123456789ABCDEF";

		static public char getDigit(int index)
		{

			return digits[index];
		}




		static public int getIndex(char symbol)
		{
			return digits.IndexOf(symbol);	///The zero-based index position of value if that character is found, or -1 if it is not.


		
		

		}

		static public int GetIndexCaseInsensitive(char symbol)
		{
			return getIndex(char.ToUpper(symbol));


		}

		static public int Parse(string hexString)
		{
			hexString = hexString.Trim();

			if (string.IsNullOrWhiteSpace(hexString))
			{
				return 0;

			}
			return int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
		}





	}
}
