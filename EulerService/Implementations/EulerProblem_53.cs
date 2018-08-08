using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using System.Diagnostics;

using _calc = MathService.Calculators.Calculator;


namespace EulerService.Implementations
{
    public static class EulerProblem53
    {
        //https://projecteuler.net/problem=53 Published on Friday, 8th March 2002, 06:00 pm;  Difficulty rating: 5% ------------- completed
        //                                      
        //
        // There are exactly ten ways of selecting three from five, 12345:
        //
        // 123, 124, 125, 134, 135, 145, 234, 235, 245, and 345
        //
        // In combinatorics, we use the notation, 5C3 = 10.
        //
        // In general,
        //
        // nCr = n!/ (r!(n−r)!)   ,where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1.
        // 
        // It is not until n = 23, that a value exceeds one-million: 23C10 = 1144066.
        //
        // How many, not necessarily distinct, values of nCr, for 1 ≤ n ≤ 100, are greater than one-million?

        public static object RunProblem(double x, double y = 0, double z = 0)
        {
            var counter = 0;

            for(var i = 23; i <= 100; i++)
            {
                var bigI = new BigInteger(i);
                for (var j = 4; j <= 96; j++)
                    if (_calc.nCr(bigI, new BigInteger(j)) > 1000000)
                        counter++;
            }
                

            return new { result = counter };
        }
        
        public static int CountFactors(int num)
        {
            var count = 1;
            var factorization = _calc.GetPrimeFactorization(num);
            var vals = factorization.Values.ToArray();

            for (var i = 0; i < vals.Length; i++)
                count *= vals[i] + 1;

            return count;
        }
    }    
}
