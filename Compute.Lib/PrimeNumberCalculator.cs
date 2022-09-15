using System.Diagnostics;
using System.Reflection.Metadata;

namespace Compute.Lib;

public class PrimeNumberCalculator
{
    public List<int> ComputePrimesWithSieveOfEratosthenes(int upperBound)
    {
        List<int> primeNumbers = new();
        bool[] A = new bool[upperBound + 1];
        for (int i = 2; i < A.Length - 1; i++)
        {
            A[i] = true;
        }

        for (int i = 2; i < Math.Sqrt(upperBound); i++)
        {
            if (A[i])
            {
                int j = i * i;
                while (j <= upperBound)
                {
                    A[j] = false;
                    j += i;
                }
            }
        }

        for (int i = 0; i < A.Length - 1; i++)
        {
            if (A[i])
            {
                primeNumbers.Add(i);
            }
        }

        return primeNumbers;
    }

    public List<int> ComputePrimesWithSieveOfSundaram(int upperBound)
    {
        int k = (int) Math.Round((double) (upperBound - 2) / 2, MidpointRounding.ToZero);
        List<int> primeNumbers = new();
        bool[] A = new bool[k + 1];
        for (int i = 2; i < A.Length - 1; i++)
        {
            A[i] = true;
        }

        for (int i = 1; i < Math.Sqrt(k); i++)
        {
            int j = i;
            while (i + j + 2 * i * j <= k)
            {
                A[i + j + 2 * i * j] = false;
                j++;
            }
        }
        primeNumbers.AddRange(new []{ 2, 3});
        for (int i = 0; i < A.Length - 1; i++)
        {
            if (A[i])
            {
                primeNumbers.Add(2 * i + 1);
            }
        }

        return primeNumbers;
    }

    // https://www.geeksforgeeks.org/sieve-of-atkin/
    public List<int> ComputePrimesWithSieveOfAtkin(int limit)
    {

        List<int> primes = new();
        primes.AddRange(new[] { 2, 3});

        // Initialise the sieve array with
        // false values
        bool[] sieve = new bool[limit + 1];

        for (int i = 0; i <= limit; i++)
        {
            sieve[i] = false;
        }

        /* Mark sieve[n] is true if one of the
        following is true:
        a) n = (4*x*x)+(y*y) has odd number
           of solutions, i.e., there exist
           odd number of distinct pairs
           (x, y) that satisfy the equation
           and    n % 12 = 1 or n % 12 = 5.
        b) n = (3*x*x)+(y*y) has odd number
           of solutions and n % 12 = 7
        c) n = (3*x*x)-(y*y) has odd number
           of solutions, x > y and n % 12 = 11 */
        for (int x = 1; x * x <= limit; x++)
        {
            for (int y = 1; y * y <= limit; y++)
            {
                // Main part of Sieve of Atkin
                int n = (4 * x * x) + (y * y);
                if (n <= limit
                    && (n % 12 == 1 || n % 12 == 5))

                {
                    sieve[n] ^= true;
                }

                n = (3 * x * x) + (y * y);
                if (n <= limit && n % 12 == 7)
                {
                    sieve[n] ^= true;
                }

                n = (3 * x * x) - (y * y);
                if (x > y && n <= limit
                          && n % 12 == 11)
                {
                    sieve[n] ^= true;
                }
            }
        }

        // Mark all multiples of squares as
        // non-prime
        for (int r = 5; r * r < limit; r++)
        {
            if (sieve[r])
            {
                for (int i = r * r;
                     i < limit;
                     i += r * r)
                {
                    sieve[i] = false;
                }
            }
        }

        // Print primes using sieve[]
        for (int a = 5; a <= limit; a++)
        {
            if (sieve[a])
            {
                primes.Add(a);
            }
        }

        return primes;
    }
}