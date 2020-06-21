using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadLines("output.txt").Last();

            BigInteger startNumber = BigInteger.Parse(input);

            Console.WriteLine("Prime Number Calculation");
            Console.WriteLine("By M. Verstraelen");
            Console.WriteLine("========================");
            Console.WriteLine();
            Console.WriteLine("Last found prime number was {0}.", startNumber.ToString());
            Console.WriteLine("Starting calculations from {0}.", (++startNumber).ToString());
            Console.WriteLine();
            Console.WriteLine("Press ENTER to start...");
            Console.ReadLine();

            while (true)
            {
                if (IsPrime(startNumber) == true)
                {
                    Console.WriteLine("PRIME! Adding to list.");
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"output.txt", true))
                    {
                        file.WriteLine(startNumber.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Not prime... Next!");
                }

                Console.WriteLine();
                startNumber++;
            }
        }

        static bool IsPrime(BigInteger number)
        {
            BigInteger counter;
            BigInteger sqrtTop;
            BigInteger remainder;

            sqrtTop = BigSqrt(number);
            Console.WriteLine("Researching if {0} is prime: dividing by 2 to {1}...", number.ToString(), sqrtTop.ToString());
            counter = 1;
            while (counter++ < sqrtTop)
            {
                //Console.WriteLine("Now dividing {0} by {1}", number.ToString(), counter.ToString());
                remainder = BigInteger.Remainder(number, counter);
                //Console.WriteLine("-- Remainder: {0}", remainder.ToString());
                //Console.WriteLine();
                if (remainder == 0)
                {
                    return false;
                }
            }
            return true;
        }
        
        static BigInteger BigSqrt(BigInteger number)
        {
            BigInteger sqrt = 0;
            BigInteger XnMinus1 = 1;
            BigInteger Xn = XnMinus1;
            

            while (Xn != sqrt)
            {
                sqrt = Xn;

                // Newton's method for sqrt calculations
                // Iterate until integer doesn't change anymore
                // Formula: x_n = x_(n-1) - [x_(n-1)-number]/2x_(n-1)

                Xn = XnMinus1 - ((XnMinus1 * XnMinus1) - number) / (2 * XnMinus1);

                XnMinus1 = Xn;

            }

            return sqrt;
        }

    }
}
