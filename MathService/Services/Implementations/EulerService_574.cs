﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using MathService.Services.Contracts;
using MathService.Models.EulerModels;


namespace MathService.Services.Implementations
{
    public partial class EulerService : IEulerService
    {
        //Problem 574 --- https://projecteuler.net/problem=574
        //Published on Sunday, 16th October 2016, 10:00 am; Solved by 191; Difficulty rating: 50%
        //
        //Let q be a prime and A≥B>0 be two integers with the following properties:
        //
        //   1. A and B have no prime factor in common, that is gcd(A,B)=1.
        //   2. The product AB is divisible by every prime less than q.
        //
        //It can be shown that, given these conditions, 
        //any sum A+B<q2 and any difference 1<A−B<q2 has to be a prime number. 
        //Thus you can verify that a number p is prime by showing that either 
        //p=A+B<q^2 or p=A−B<q^2 for some A,B,q fulfilling the conditions listed above.
        //
        //Let V(p) be the smallest possible value of A in any sum p=A+B and any difference p=A−B, 
        //that verifies p being prime. 
        //
        //Examples:
        // V(2)=1, since 2=1+1<2^2. 
        // V(37)=22, since 37=22+15=2*11+3*5<7^2 is the associated sum with the smallest possible A.
        // V(151)=165 since 151=165−14=3⋅5⋅11−2⋅7<132 is the associated difference with the smallest possible A.
        //
        //Let S(n) be the sum of V(p) for all primes p<n. For example, 
        //
        //S(10)=10 and S(200)=7177.
        //
        //Find S(3800).
        public object RunProblem574(int x)
        {
            long result = 0;


            return result;
        }
    }
}
