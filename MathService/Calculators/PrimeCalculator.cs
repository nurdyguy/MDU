using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using _primeRepo = MathService.Repositories.Constants.PrimesRepository;


namespace MathService.Calculators
{
    public static partial class Calculator 
    {
        
        public static bool IsPrime(ulong num)
        {
            return _primeRepo.IsPrime((int)num);
        }

        public static bool IsPrime(int num)
        {
            return _primeRepo.IsPrime((int)num);
        }

        public static int GetPrime(int index)
        {
            return _primeRepo.GetPrime(index);
        }
        public static List<int> GetAllPrimes(int max)
        {
            return _primeRepo.GetAllPrimes(max);
        }
        public static List<int> GetAllPrimes(long max)
        {
            return _primeRepo.GetAllPrimes(max);
        }
        public static List<int> GetAllPrimes(ulong max)
        {
            return _primeRepo.GetAllPrimes(max);
        }
        public static List<int> GetFirstNPrimes(int n)
        {
            return _primeRepo.GetFirstNPrimes(n);
        }

        public static BitArray GetPrimeBitArray(int length)
        {
            return _primeRepo.GetPrimeBitArray(length);
        }
        public static List<bool> SieveOfErat(int max)
        {
            return _primeRepo.SieveOfErat(max);
        }

        public static ulong GetPrimeCount(int max)
        {
            return _primeRepo.GetPrimeCount(max);
        }
        public static ulong GetPrimeCount(long max)
        {
            return _primeRepo.GetPrimeCount(max);
        }

        public static ulong GetPrimeCount(ulong max)
        {
            return _primeRepo.GetPrimeCount(max);
        }
    }
}
