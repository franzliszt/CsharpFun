using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPractise {
    public static class TempConverter {
        public static double CelsiusToFarenheit(string celsius) {
            double c = Double.Parse(celsius);
            double f = (c * 9 / 5) + 32;
            return f;
        }

        public static double FarenheitToCelsius(string faren) {
            double f = Double.Parse(faren);
            double c = (f - 32) * 5 / 9;
            return c;
        }
    }
}
