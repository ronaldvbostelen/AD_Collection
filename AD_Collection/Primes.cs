using System;
using System.Collections.Generic;
using System.Linq;

namespace AD_Collection
{
    public static class Primes
    {
        public static List<int> SieveOfEratosthenes(int amountOfPrimes)
        {
            var boolPrimes = new bool[(long)Math.Pow(amountOfPrimes, 3)];
            var primeNumbers = new List<int>();
            var firstPrime = 2;

            for (int i = 0; i < boolPrimes.Length; i++)
            {
                boolPrimes[i] = true;
            }

            for (var prime = firstPrime; prime * prime < boolPrimes.Length; prime++)
            {
                if (boolPrimes[prime])
                {
                    primeNumbers.Add(prime);
                    Console.WriteLine($"#{primeNumbers.Count} PRIME = {prime}");

                    if (primeNumbers.Count >= amountOfPrimes)
                    {
                        break;
                    }

                    for (var notAPrime = prime * prime; notAPrime < boolPrimes.Length; notAPrime += prime)
                    {
                        boolPrimes[notAPrime] = false;
                    }
                }
            }

            return primeNumbers;
        }


        public static List<int> NaievePrimeFinder(int amountOfPrimes)
        {
            var prime = 2;
            var primes = new List<int> { prime };
            while (primes.Count < amountOfPrimes)
            {
                prime++;

                if (primes.All(x => prime % x != 0))
                {
                    primes.Add(prime);
                }
            }

            return primes;
        }
    }
}