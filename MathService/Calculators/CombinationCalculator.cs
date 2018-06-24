using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Diagnostics;

using _combRepo = MathService.Repositories.Constants.CombinationsRepository;

namespace MathService.Calculators
{
    public static partial class Calculator
    {
        // Encoding/Decoding a combination implies an order:
        //      lexicographic means (0, 1, 2, 3, 4, ..., max) is the very first combination so id = 1
        // 
        // converts Combination into integer
        // max is the largest possible number
        public static BigInteger EncodeCombination(List<int> comb, int max)
        {
            var id = _combRepo.nCr(max + 1, comb.Count);
            for (int i = 0; i < comb.Count; i++)
                id -= _combRepo.nCr(max - comb[i], comb.Count - i);
            return id;            
        }

        // gets Combination from integer 
        public static List<int> DecodeCombination(BigInteger id, int max, int combLength)
        {
            List<int> comb = new List<int>(combLength);
            var tId = _combRepo.nCr(max + 1, combLength) - id;
            for (int i = combLength; i > 0; i--)
            {
                var tVal = BigInteger.Zero;
                bool done = false;
                int pos = 0;
                while (!done)
                {
                    var t = _combRepo.nCr(max - pos, i);
                    if (t <= tId)
                    {
                        tVal = t;
                        done = true;
                    }
                    pos++;
                }
                tId -= tVal;
                comb.Add(pos - 1);
            }

            return comb;

        }
        
        public static List<List<int>> GenAllCombinations(int max)
        {
            var combs = new List<List<int>>();
            for (var i = 0; i <= max; i++)
            {
                var num = _combRepo.nCr(max, i);
                for (var id = BigInteger.One; id <= num; id++)
                {
                    var comb = DecodeCombination(id, max - 1, i);
                    combs.Add(comb);
                }
            }

            return combs;
        }

        public static BigInteger nCr(BigInteger n, BigInteger r)
        {
            return _combRepo.nCr(n, r);
        }
    }

    public class Combination
    {
        public List<int> comb { get; set; }
        public int order { get; set; }
    }
}
