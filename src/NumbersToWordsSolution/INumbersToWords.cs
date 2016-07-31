using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NumbersToWordsSolution
{
    public interface INumbersToWords
    {
        string Convert(decimal number, NumberFormatInfo nfi);
    }
}
