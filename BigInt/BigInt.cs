using System;

class BigInt
{
    private const int precision = 8; 
    
    private static int mod = (int)Math.Pow(10, precision);

    private static void split(string a, out int[] seg)
    {
        try
        {
            if (a == "")
            {
                throw new System.ArgumentException("Input should not be empty!");
            }

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

                try
                {
                    seg[curSegInx] = Convert.ToInt32(a.Substring(curPos, segLength));
                }
                catch (System.FormatException)
                {
                    throw;
                }
            }
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    private static void swap(ref int[] aSeg, ref int[] bSeg)
    {
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

        int[] cSeg = new int[upper];

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

    private static void clear(ref int[] seg)
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

    private static string arrToString(int[] seg)
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

    private static string bigIntAdd(string a, string b)
    {
        int[] aSeg;
        int[] bSeg;

        try
        {
            split(a, out aSeg);
        }
        catch (System.Exception)
        {
            throw;
        }

        try
        {
            split(b, out bSeg);
        }
        catch (System.Exception)
        {
            throw;
        }

        if (aSeg.Length > bSeg.Length)
        {
            swap(ref aSeg, ref bSeg);
        }

        int[] cSeg = new int[bSeg.Length + 1];

        for (int i = 0; i < aSeg.Length; i++)
        {
            cSeg[i] = aSeg[i] + bSeg[i];
        }

        for (int i = aSeg.Length; i < bSeg.Length; i++)
        {
            cSeg[i] = bSeg[i];
        }

        clear(ref cSeg);

        return arrToString(cSeg);
    }

    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        char[] delim = new char[] { ' ' };
        string[] ints = input.Split(delim, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("a = {0}, b = {1}", ints[0], ints[1]);

        try
        {
            Console.WriteLine("a + b = {0}", bigIntAdd(ints[0], ints[1]));
        }
        catch (System.FormatException)
        {
            Console.WriteLine("Format Error!");
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
