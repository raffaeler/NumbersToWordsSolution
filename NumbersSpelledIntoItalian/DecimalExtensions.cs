using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NumbersToWordsSolution
{
    public static class DecimalExtensions
    {
        public static string AsString(this decimal number, bool excludeZeroDecimals = false)
        {
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
            return AsString(number, excludeZeroDecimals, ci);
        }

        public static string AsString(this decimal number, bool excludeZeroDecimals, CultureInfo cultureInfo)
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
            return converter.Convert(number, excludeZeroDecimals, nfi);
        }
    }
}
