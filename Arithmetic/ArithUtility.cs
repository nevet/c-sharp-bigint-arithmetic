using System;

namespace Arithmetic
{
    class ArithUtility
    {
        private static int precision = Config.getPrecision();
        private static int maxArrLen = Config.getMaxArrLen();
        private static int mod = Config.getMod();

        public static void split(string a, out int[] seg)
        {
            int totSegLength = (a.Length - 1) / precision + 1;

            seg = new int[totSegLength];

            int curPos = a.Length - precision;
            int curSegInx = 0;
            int segLength = precision;

            for (; curPos != -precision; curPos -= precision, ++curSegInx)
            {
                if (curPos < 0)
                {
                    segLength = curPos + precision;
                    curPos = 0;
                }

                seg[curSegInx] = Convert.ToInt32(a.Substring(curPos, segLength));
            }
        }

        public static void swap(ref int[] aSeg, ref int[] bSeg)
        {
            int[] cSeg = new int[maxArrLen];

            int upper = aSeg.Length;
            int aOriSize = aSeg.Length, bOriSize = bSeg.Length;

            if (aSeg.Length < bSeg.Length)
            {
                upper = bSeg.Length;
                Array.Resize(ref aSeg, upper);
            }
            else
            {
                Array.Resize(ref bSeg, upper);
            }

            for (int i = 0; i < upper; i++)
            {
                cSeg[i] = aSeg[i];
                aSeg[i] = bSeg[i];
                bSeg[i] = cSeg[i];
            }

            if (aOriSize < bOriSize)
            {
                Array.Resize(ref bSeg, aOriSize);
            }
            else
            {
                Array.Resize(ref aSeg, bOriSize);
            }
        }

        public static void clear(ref int[] seg)
        {
            for (int i = 0; i < seg.Length - 1; i++)
            {
                seg[i + 1] += seg[i] / mod;
                seg[i] %= mod;
            }

            if (seg[seg.Length - 1] == 0)
            {
                Array.Resize(ref seg, seg.Length - 1);
            }
        }

        public static string arrToString(int[] seg)
        {
            string s = seg[seg.Length - 1].ToString();

            for (int i = seg.Length - 2; i >= 0; i--)
            {
                int p = 10;

                for (int j = 0; j < precision - 1; j++, p *= 10)
                {
                    if (seg[i] < mod / p)
                    {
                        s += '0';
                    }
                    else
                    {
                        break;
                    }
                }

                s += seg[i].ToString();
            }

            return s;
        }
    }
}
