using System;

namespace Arithmetic
{
    public class Config
    {
        private static int precision = 4;
        private static int maxDigLen = 1000;
        private static int maxArrLen = maxDigLen / precision * 2 + 1;
        private static int mod = (int)Math.Pow(10, precision);

        public static void setPrecision(int v)
        {
            precision = v;
            maxArrLen = maxDigLen / precision * 2 + 1;
            mod = (int)Math.Pow(10, precision);
        }

        public static void setMaxDigLen(int v)
        {
            maxDigLen = v;
            maxArrLen = maxDigLen / precision * 2 + 1;
        }

        public static int getPrecision()
        {
            return precision;
        }

        public static int getMaxDigLen()
        {
            return maxDigLen;
        }

        public static int getMaxArrLen()
        {
            return maxArrLen;
        }

        public static int getMod()
        {
            return mod;
        }
    }
}
