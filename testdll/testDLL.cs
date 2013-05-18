using System;
using Arithmetic;

namespace testdll
{
    class testDLL
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 1;

            Console.WriteLine("Predefined Ints: a = {0}, b = {1}", a, b);
            Console.WriteLine("a + b = {0}", Add.add(a, b));
            Console.WriteLine("a * b = {0}", Multiply.mul(a, b));
            
            string input = Console.ReadLine();
            char[] delim = new char[] { ' ' };
            string[] ints = input.Split(delim, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("a = {0}, b = {1}", ints[0], ints[1]);
            Console.WriteLine("a + b = {0}", Add.bigIntAdd(ints[0], ints[1]));

            try
            {
                a /= b;
            }
            catch (System.DivideByZeroException)
            {
                Console.WriteLine("divided by zero!");
            }
            finally
            {
                Console.WriteLine("Inside Finally.");
            }

            Console.WriteLine("After Exception.");
        }
    }
}
