using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirographGenerator
{
    public static class MathHelpers
    {
        public static int GetGcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            if (b > a)
            {
                return GetGcd(b, a);
            }

            return GetGcd(b, a % b);
        }
    }
}
