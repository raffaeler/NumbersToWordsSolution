using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

using NumbersToWordsSolution;

namespace TestConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo ci = new CultureInfo("it");

            Debug.Assert(122460.6m.ConvertToWords(ci) == "centoventiduemilaquattrocentosessanta/60");
            Debug.Assert(22460.6m.ConvertToWords(ci) == "ventiduemilaquattrocentosessanta/60");
            Debug.Assert(3240.5m.ConvertToWords(ci) == "tremiladuecentoquaranta/50");
            Debug.Assert(240.5m.ConvertToWords(ci) == "duecentoquaranta/50");
            Debug.Assert(400m.ConvertToWords(ci) == "quattrocento/00");
        }
    }
}
