using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using System.Diagnostics;

using _calc = MathService.Calculators.Calculator;

namespace EulerService.Implementations
{
    public static class EulerProblem357
    {
        //https://projecteuler.net/problem=357 Published on Saturday, 5th November 2011, 04:00 pm;   Difficulty rating: 10% ------------- 
        //                                      
        //
        // Consider the divisors of 30: 1,2,3,5,6,10,15,30.
        // It can be seen that for every divisor d of 30, d+30/d is prime.
        //
        // Find the sum of all positive integers n not exceeding 100 000 000
        //
        // such that for every divisor d of n, d+n/d is prime.
        //
        // Notes:
        // 1.  must be 1 less than a prime
        // 2.  all prime factors divide in exactly once
        // 3.  1 and 2 satisfy

        public static object RunProblem(double x, double y = 0, double z = 0)
        {
            // account for 1 and 2
            var sum = 3;

            var _p = _calc.GetAllPrimes(100000000);

            var candidates = new List<int>();
            for(var i = 1; i < _p.Count; i++)
            {
                var factorization = _calc.GetPrimeFactorization(_p[i] - 1);
                var pows = factorization.Values.ToList();
                if(!pows.Any(p => p > 1))
                {
                    candidates.Add(_p[i] - 1);
                }
            }

            


            return new { result = sum };
        }
        
        public static bool CheckDivisors(int num, List<int> primeFactors)
        {

            for (var i = 0; i < primeFactors.Count; i++)
                if (false)
                    return false;


            return true;
        }
    }    
}
