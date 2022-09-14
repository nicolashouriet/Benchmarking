using System.Reflection.Metadata;
using Compute;

namespace Benchmarking;

public class PrimeComputationCorrectnessTests
{
    [Theory]
    [InlineData(100_000)]
    public void PrimeComputationAlgorithmsAreCorrectlyImplemented(int upperBound)
    {
        List<int> correctPrimesUpToX = File.ReadLines("../primesUpTo100_000.txt").Select(l => int.Parse(l)).ToList();
        Assert.True(IsListOfReturnedPrimesWithEratostheneCorrectUpTo(upperBound, correctPrimesUpToX));
        Assert.True(IsListOfReturnedPrimesWithSundaramCorrectUpTo(upperBound, correctPrimesUpToX));
        Assert.True(IsListOfReturnedPrimesWithAtkinCorrectUpTo(upperBound, correctPrimesUpToX));
    }

    bool IsListOfReturnedPrimesWithEratostheneCorrectUpTo(int upperBound, List<int> correctPrimesUpToX)
    {
        List<int> primes = correctPrimesUpToX.Take(upperBound).ToList();

        PrimeNumberCalcultator calc = new PrimeNumberCalcultator();
        List<int> actual = calc.ComputePrimesWithSieveOfEratosthenes(upperBound);
        
        return primes.Except(actual).Any() && primes.Count == actual.Count;
    }
    
    bool IsListOfReturnedPrimesWithSundaramCorrectUpTo(int upperBound, List<int> correctPrimesUpToX)
    {
        List<int> primes = correctPrimesUpToX.Take(upperBound).ToList();

        PrimeNumberCalcultator calc = new PrimeNumberCalcultator();
        List<int> actual = calc.ComputePrimesWithSieveOfSundaram(upperBound);
        
        return primes.Except(actual).Any() && primes.Count == actual.Count;
    }
    
    bool IsListOfReturnedPrimesWithAtkinCorrectUpTo(int upperBound, List<int> correctPrimesUpToX)
    {
        List<int> primes = correctPrimesUpToX.Take(upperBound).ToList();

        PrimeNumberCalcultator calc = new PrimeNumberCalcultator();
        List<int> actual = calc.ComputePrimesWithSieveOfAtkin(upperBound);
        
        return primes.Except(actual).Any() && primes.Count == actual.Count;
    }
}