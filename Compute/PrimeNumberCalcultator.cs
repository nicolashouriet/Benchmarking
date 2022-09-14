using System.Reflection.Metadata;

namespace Compute;

public class PrimeNumberCalcultator
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
        int k = (int)Math.Round((double)(upperBound - 1) / 2, MidpointRounding.ToZero);
        List<int> primeNumbers = new();
        bool[] A = new bool[k + 1];
        for (int i = 0; i < A.Length - 1; i++)
        {
            A[i] = true;
        }

        for (int i = 1; i < Math.Sqrt(k); i++)
        {
            int j = i;
            while (i + j + 2 * i * j < k)
            {
                A[i + j + 2 * i * j] = false;
                j++;
            }
        }

        for (int i = 0; i < A.Length - 1; i++)
        {
            if (A[i])
            {
                primeNumbers.Add(2 * i + 1);
            }
        }

        return primeNumbers;
    }

    public List<int> ComputePrimesWithSieveOfAtkin(int upperBound)
    {
        int[] S = new[] {1, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 49, 53, 59};
        bool[] A = new bool[upperBound];
        List<int> primeNumbers = new();

        int[] loop1ValidRemainders = new[] {1, 13, 17, 29, 37, 41, 49, 53};
        for (int x = 1; x < Math.Sqrt(upperBound); x++)
        {
            for (int y = 1; y < Math.Sqrt(upperBound); y+=2)
            {
                int m = 4 * x * x + y * y;
                if (m <= upperBound && loop1ValidRemainders.Contains(m % 60))
                {
                    A[m] = !A[m];
                }
            }
        }

        int[] loop2ValidRemainders = new[] {7, 19, 31, 43};
        for (int x = 1; x < Math.Sqrt(upperBound); x+=2)
        {
            for (int y = 2; y < Math.Sqrt(upperBound); y+=2)
            {
                int m = 3 * x * x + y * y;
                if (m <= upperBound && loop2ValidRemainders.Contains(m % 60))
                {
                    A[m] = !A[m];
                }
            }
        }

        int[] loop3ValidRemainders = new[] {11, 23, 47, 59};
        for (int x = 2; x < Math.Sqrt(upperBound); x++)
        {
            for (int y = upperBound - 1; y > 1; y-=2)
            {
                int m = 3 * x * x - y * y;
                if (m <= upperBound && loop3ValidRemainders.Contains(m % 60))
                {
                    A[m] = !A[m];
                }
            }
        }

        int[] M = new int[S.Length];
        int mIndex = 0;
        foreach (var sAndw in S.Zip(Enumerable.Range(0, upperBound / 60)))
        {
            M[mIndex++] = 60 * sAndw.Second + sAndw.First;
        }

        List<int> mList = M.ToList();
        mList.Remove(1);
        
        for (int m = 0; m < mList.Count - 1; m++)
        {
            if (m * m > upperBound)
            {
                break;
            }

            int mm = m * m;
            if (A[m])
            {
                for (int m2 = 0; m2 < M.Length - 1; m2++)
                {
                    int c = mm * m2;
                    if (c > upperBound)
                    {
                        break;
                    }
                    A[c] = false;
                }
            }
        }
        primeNumbers.AddRange(new int[] { 2, 3, 5});

        for (int i = 0; i < A.Length - 1; i++)
        {
            if (A[i])
            {
                primeNumbers.Add(i);
            }
        }

        return primeNumbers;
    }
}