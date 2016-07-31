using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NumbersToWordsSolution
{
    public static class DecimalExtensions
    {
        public static string ConvertToWords(this decimal number)
        {
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
            return ConvertToWords(number, ci);
        }

        public static string ConvertToWords(this decimal number, CultureInfo cultureInfo)
        {
            INumbersToWords converter;
            switch (cultureInfo.TwoLetterISOLanguageName)
            {
                case "it":
                    converter = new NumbersToWordsItalian();
                    break;
                default:
                    throw new NotImplementedException(string.Format("No converter defined for language: {0} / {1}", cultureInfo.TwoLetterISOLanguageName, cultureInfo.EnglishName));
            }

            System.Globalization.NumberFormatInfo nfi = cultureInfo.NumberFormat;
            return converter.Convert(number, nfi);
        }
    }
}
