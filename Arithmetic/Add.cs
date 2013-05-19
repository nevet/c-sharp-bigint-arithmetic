using System;

namespace Arithmetic
{
    public class Add
    {
        public static int add(int a, int b)
        {
            return a + b;
        }
        
        public static long add(long a, long b)
        {
            return a + b;
        }

        public static string bigIntAdd(string a, string b)
        {
            int[] aSeg, bSeg;

            ArithUtility.split(a, out aSeg);
            ArithUtility.split(b, out bSeg);

            if (aSeg.Length > bSeg.Length)
            {
                ArithUtility.swap(ref aSeg, ref bSeg);
            }

            int[] cSeg = new int[bSeg.Length + 1];

            for (int i = 0; i < aSeg.Length; i ++)
            {
                cSeg[i] = aSeg[i] + bSeg[i];
            }

            for (int i = aSeg.Length; i < bSeg.Length; i ++)
            {
                cSeg[i] = bSeg[i];
            }

            ArithUtility.clear(ref cSeg);

            return ArithUtility.arrToString(cSeg);
        }
    }

    public class Minus
    {
        public static int minus(int a, int b)
        {
            return a - b;
        }
    }

    public class Multiply
    {
        public static int mul(int a, int b)
        {
            return a * b;
        }

        public static long mul(long a, long b)
        {
            return a * b;
        }

        public static string bigIntMul(string a, string b)
        {
            int aSeg[], bSeg[];

            ArithUtility.split(a);
            ArithUtility.split(b);

            int[] cSeg = new int[aSeg.Length + bSeg.Length + 1];

            for (int i = 0; i < aSeg.Length; i ++)
            {
                for (int j = 0; j < bSeg.Length; j ++)
                {
                    cSeg[i + j] = aSeg[i] * bSeg[j];
                }
            }

            ArithUtility.clear(ref cSeg);

            return ArithUtility.arrToString(cSeg);
        }
    }
}