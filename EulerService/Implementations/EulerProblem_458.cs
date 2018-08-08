using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using System.Diagnostics;

using _calc = MathService.Calculators.Calculator;

namespace EulerService.Implementations
{
    public static class EulerProblem458
    {
        //https://projecteuler.net/problem=458 Published on Sunday, 9th February 2014, 07:00 am; Solved by 641; Difficulty rating: 30%------------- incomplete
        //                                      
        //
        // Consider the alphabet A made out of the letters of the word "project": A={c,e,j,o,p,r,t}.
        // Let T(n) be the number of strings of length n consisting of letters from A that do not have 
        // a substring that is one of the 5040 permutations of "project".
        //
        // T(7)=7^7-7!=818503.
        // Find T(10^12). Give the last 9 digits of your answer.
        // Notes:
        // 1.  7^(10^12) possible words 
        // 2.  7! = 5040 possible permutations of A
        // 3.  if perm of A is a substring then there are 10^12 - 6 possible starting positions
        // 4.  words WITH perm of A = (10^12 - 6) * 7! * 7^(10^12 - 7) ???
        // 5.  7^n - (n - 6) * 7! * 7^(n - 7) = 7^(n - 7) * [7^7 - (n - 6) * 7!]
        // ---------- this double counts :-(    projectjproject gets counted twice n = 15
        // 6.  7^(n - 7) * 5040 * (n - 6)! ?

        public static object RunProblem(double x, double y = 0, double z = 0)
        {
            //var bigTrill = BigInteger.Pow(10, 12);
            //var longTrill = 1000000000000;

            //var sevToTrill = SevenToTrillion();


            //var permsWithWord = (longTrill - 6) * 5040 * BigInteger.Pow(7, 10^12 - 7);
            //var answer = sevToTrill - permsWithWord;
            // 
            //  = 7^999999999993 * (7^7 - (longTrill - 6) * 5040) 

            var answer = BigInteger.ModPow(7, 999999999993, 1000000000000) * (BigInteger.Pow(7, 7) - BigInteger.Parse("999999999994") * 5040);

            return new { result = answer };
        }

        private static BigInteger SevenToTrillion()
        {
            var x = BigInteger.ModPow(7, 999999999993, 1000000000000);
            //var y = BigInteger.ModPow(x, 1000000, 1000000000000);
            return x;
        }
        
    }    
}
