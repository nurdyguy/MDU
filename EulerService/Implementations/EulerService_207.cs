using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using System.Diagnostics;

using _calc = MathService.Calculators.Calculator;

namespace EulerService.Implementations
{
    public static class EulerProblem207   
    {
        //https://projecteuler.net/problem=207 difficulty: 40% ---------------completed
        //
        //For some positive integers k, there exists an integer partition of the form   4^t = 2^t + k,
        //where 4t, 2t, and k are all positive integers and t is a real number.

        //The first two such partitions are 4^1 = 2^1 + 2 and 4^1.5849625... = 2^1.5849625... + 6.

        //Partitions where t is also an integer are called perfect.
        //For any m ≥ 1 let P(m) be the proportion of such partitions that are perfect with k ≤ m.
        //Thus P(6) = 1/2.

        //In the following table are listed some values of P(m)

        //   P(5) = 1/1
        //   P(10) = 1/2
        //   P(15) = 2/3
        //   P(20) = 1/2
        //   P(25) = 1/2
        //   P(30) = 2/5
        //   ...
        //   P(180) = 1/4
        //   P(185) = 3/13

        // Find the smallest m for which P(m) < 1/12345                                                                                                                                                                                                                            

        //-----------------------------------------------------------------------------------
        //Notes:
        // 1.  if 4^t - 2^t = k --- list all possibilities 2^t = 2, 3, 4, ....  
        // 2.  when 2^t is a power of 2 then we are "perfect"
        // 3.  k = (2^t)^2 - 2^t
        // 4.  close to 50000000000

        private static List<ulong> _twoPowers = new List<ulong>(){ 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864,
            134217728, 268435456, 536870912, 1073741824, 2147483648, 4294967296, 8589934592, 17179869184, 34359738368, 68719476736, 137438953472, 274877906944, 549755813888, 1099511627776, 2199023255552, 4398046511104, 8796093022208, 17592186044416, 35184372088832,
            70368744177664, 140737488355328, 281474976710656, 562949953421312, 1125899906842624, 2251799813685248, 4503599627370496, 9007199254740992, 18014398509481984, 36028797018963968, 72057594037927936, 144115188075855872, 288230376151711744, 576460752303423488,
            1152921504606846976, 2305843009213693952, 4611686018427387904, 9223372036854775808 };

        public static object RunProblem(double x, double y = 0, double z = 0)
        {
            var stop = 1 / x;
            long min = 10;
            long max = 50000000000;
            var result = new PartitionResult();
            while(max - min > 1)
            {
                var mid = (max + min) / 2;
                result = CalcP(mid);
                if ((double)result.PerfectCounter / result.TotalCounter >= stop)
                    min = mid;
                else
                    max = mid;

            }
            return new { result, max };
        }
        
        private static PartitionResult CalcP(long max)
        {
            var perfCounter = 0;
            long k = 2;

            for(k = 2; k* k - k <= max; k++)
            {
                if (_twoPowers.Contains((ulong) k))
                    perfCounter++;
                
            }
            return new PartitionResult{ PerfectCounter = perfCounter, TotalCounter = k - 2 };
        }
        
        private class PartitionResult
        {
            public long PerfectCounter { get; set; }
            public long TotalCounter { get; set; }
        }
    }    
}
