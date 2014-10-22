using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{
	public class HexDigits
	{
		static public char getDigit(int index)
		{

			switch (index)
			{
				case 0:
					return '0';
					break;
				case 1:
					return '1';
				case 2:
					return '2';
					break;
				case 3: return '3';
				case 4: return '4';
				case 5: return '5';
				case 6: return '6';
				case 7: return '7';
				case 8: return '8';
				case 9: return '9';
				case 10: return 'A';
				case 11: return 'B';
				case 12: return 'C';
				case 13: return 'D';
				case 14: return 'E';
				case 15: return 'F';

				default:
					throw new Exception("Expected an integer in [0,15]");
					break;
			}


		}

		static public int getIndex(char symbol)
		{
			switch (symbol)
			{
				case '0': return 0;
				case '1': return 1;
				case '2': return 2;
				case '3': return 3;
				case '4': return 4;
				case '5': return 5;
				case '6': return 6;
				case '7': return 7;
				case '8': return 8;
				case '9': return 9;
				case 'A': return 10;

				case 'B': return 11;
				case 'C': return 12;
				case 'D': return 13;
				case 'E': return 14;
				case 'F': return 15;


				default:
					throw new Exception("Expected a char in {0,1,2,3,4,5,6,7,8,9,A, B,C,D,E,F}");
					break;
			}

		}

		static public int GetIndexCaseInsensitive(char symbol)
		{
			return getIndex(char.ToUpper(symbol));


		}

		static public int Parse(string hexString)
		{
			if (string.IsNullOrWhiteSpace(hexString))
			{
				return 0;

			}
			hexString = hexString.Trim();


			return int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
		}


		static public int Parse__noNull(string hexString)
		{
			


			return int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
		}



	}
}
