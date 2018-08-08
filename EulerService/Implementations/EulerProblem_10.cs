using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using System.Diagnostics;

using _calc = MathService.Calculators.Calculator;

namespace EulerService.Implementations
{
    public static class EulerProblem10
    {
        //https://projecteuler.net/problem=10 Published on Friday, 8th February 2002, 06:00 pm; Solved by 270094; Difficulty rating: 5% ------------- completed
        //                                      
        //  The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
        //
        //  Find the sum of all the primes below two million.
        // 

        public static object RunProblem(double x, double y = 0, double z = 0)
        {
            var max = (int)x;
            var _primes = _calc.GetAllPrimes(max);
            var sum = (long)0;
            for (var i = 0; i < _primes.Count; i++)
                sum += _primes[i];

            return new { result = sum };
        }
        
        
    }    
}
