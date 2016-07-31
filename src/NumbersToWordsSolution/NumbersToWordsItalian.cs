using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Copyright (c) Raffaele Rialdi, 2003
// @raffaeler, raffaeler(at)vevy(dot)com
// I initially published the source code in this thread on November 30, 2003:
// http://groups.google.com/group/microsoft.public.it.dotnet.csharp/browse_frm/thread/115b78a88be94f07/543e4900f150ed8a?q=mille+cento+raffaele&rnum=4&hl=en

namespace NumbersToWordsSolution
{
    /// <summary>
    /// Converts any number to italian words.
    /// It is intended to be used for currencies.
    /// The used format is the one used on cheques.
    /// Example: 1320,97 is converted in: "milletrecentoventi/97"
    /// The current implementation converts numbers lower than a trillion
    /// </summary> 
    public class NumbersToWordsItalian : INumbersToWords
    {
        // The word radixes in Italian language
        private static string[,] num ={
               {"zero", "uno", "due", "tre", "quattro", "cinque", "sei", "sette", "otto", "nove"},
               {"dieci", "undici", "dodici", "tredici", "quattordici", "quindici", "sedici", "diciassette", "diciotto", "diciannove"},
               {"venti", "ventuno", "", "", "", "", "", "", "ventotto", ""},
               {"trenta", "trentuno", "", "", "", "", "", "", "trentotto", ""},
               {"quaranta", "quarantuno", "", "", "", "", "", "", "quarantotto", ""},
               {"cinquanta", "cinquantuno", "", "", "", "", "", "", "cinquantotto", ""},
               {"sessanta", "sessantuno", "", "", "", "", "", "", "sessantotto", ""},
               {"settanta", "settantuno", "", "", "", "", "", "", "settantotto", ""},
               {"ottanta", "ottantuno", "", "", "", "", "", "", "ottantotto", ""},
               {"novanta", "novantuno", "", "", "", "", "", "", "novantotto", ""}
              };

        /// <summary>
        /// The convert method
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string Convert(decimal number, System.Globalization.NumberFormatInfo numberFormatInfo)
        {
            // how many decimals are expected after the comma?
            int fractnum = numberFormatInfo.CurrencyDecimalDigits;
            // The integer parts
            int Integral = (int)decimal.Truncate(number);
            // the number of decimals after the comma.
            int fractional = (int)decimal.Truncate((number - Integral) * (decimal)System.Math.Pow(10, fractnum));
            string fraction = fractional == 0 ? "00" : fractional.ToString();

            return ToString(Integral) + "/" + fraction;
        }

        /// <summary>
        /// Converts an integer
        /// </summary>
        private static string ToString(int n)
        {
            string tmp = n.ToString();

            // The list will contain strings with blocks of numbers of 1, 2 or 3 characters length
            // For example if n == 1234, the list will contain two elements: al[0] = "234" and al[1] = "1"
            var al = new List<string>();
            int i = tmp.Length;
            while (i > 3)
            {
                al.Add(tmp.Substring(i - 3, 3));
                i -= 3;
            }

            if (i != 0)
            {
                al.Add(tmp.Substring(0, i));
            }


            string result = string.Empty;
            for (int j = al.Count - 1; j >= 0; j--)
            {
                string s = al[j]; // Get the string corresponding to the block
                int blockNumber = int.Parse(s); // convert back to integer
                int first = 0, second = 0, third = 0;
                if (s.Length == 3)
                {
                    first = int.Parse(s[0].ToString());
                    second = int.Parse(s[1].ToString());
                    third = int.Parse(s[2].ToString());
                }

                if (s.Length == 2)
                {
                    second = int.Parse(s[0].ToString());
                    third = int.Parse(s[1].ToString());
                }

                if (s.Length == 1)
                {
                    third = int.Parse(s[0].ToString());
                }

                switch (j)
                {
                    case 0:   // hundreds
                        result += Tripletta(first, second, third);
                        break;

                    case 1:   // thousands
                        if (blockNumber == 1)
                            result += "mille";
                        else
                            result += Tripletta(first, second, third) + "mila";
                        break;

                    case 2:   // millions
                        if (blockNumber == 1)
                            result += "unmilione";
                        else
                            result += Tripletta(first, second, third) + "milioni";
                        break;

                    case 3:   // billions (miliardo) 
                        if (blockNumber == 1)
                            result += "unmiliardo";
                        else
                            result += Tripletta(first, second, third) + "miliardi";
                        break;

                    case 4:   // trillions (biliardo)
                        if (blockNumber == 1)
                            result += "unbiliardo";
                        else
                            result += Tripletta(first, second, third) + "biliardi";
                        break;

                    default:  // greater numbers are not supported
                              //blah += "Unsupported format";
                        throw new ArgumentException("Numbers greater than a trillion are not supported");
                }
            }

            return result;
        }

        /// <summary>
        /// Converts a triplet
        /// </summary>
        private static string Tripletta(int first, int second, int third)
        {
            string res = string.Empty;
            if (first == 1) res += "cento";
            if (first > 1) res += num[0, first] + "cento";
            string t = num[second, third];
            if (t == string.Empty) t = num[second, 0] + num[0, third];
            if (t != "zero")
                res += t;
            return res;
        }
    }
}
