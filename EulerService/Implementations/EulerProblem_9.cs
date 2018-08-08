using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using System.Diagnostics;

using _calc = MathService.Calculators.Calculator;

namespace EulerService.Implementations
{
    public static class EulerProblem9
    {
        //https://projecteuler.net/problem=9 Published on Friday, 25th January 2002, 06:00 pm; Difficulty rating: 5% ------------- completed
        //                                      
        //
        // A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
        //
        // a2 + b2 = c2
        // For example, 32 + 42 = 9 + 16 = 25 = 52.
        //
        // There exists exactly one Pythagorean triplet for which a + b + c = 1000.
        // Find the product abc.
        //
        // Notes:
        // 1.  a + b > c so max c is 499
        // 2.  a < b < c => c >= 334
        // 3.  c is divisible by 4n + 1 for some n

        public static object RunProblem(double x, double y = 0, double z = 0)
        {
            
            for(var c = 334; c < 500; c++)
                for(var b = c/2 + 1; b < c; b++)                    
                {
                    var a = 1000 - c - b;
                    if (a + b + c == 1000 && CheckPythagoreanTriple(a, b, c))
                        return new { a, b, c, result = a * b * c };
                }
            return new { result = false };
        }
        
        public static bool CheckPythagoreanTriple(int a, int b, int c)
        {
            return a * a + b * b == c * c;
        }
    }    
}
