using System.Diagnostics;
using System.Reflection.Metadata;
using Compute.Lib;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Correctness.Tests;

public class PrimeComputationCorrectnessTests
{
    [Theory]
    [InlineData(100_000)]
    public void PrimeComputationAlgorithmsAreCorrectlyImplemented(int upperBound)
    {
        string traceFile = Path.Join("D:", "riderlogs", "primecomputation.log");
        File.Delete(traceFile);
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new RollingFileTraceListener(traceFile, "primecomputation", 100_000));
        List<int> correctPrimesUpToX = File.ReadLines(Path.Join("..", "..", "../primesUpTo100_000.txt")).Select(l => int.Parse(l)).ToList();
        Assert.True(IsListOfReturnedPrimesWithEratostheneCorrectUpTo(upperBound, correctPrimesUpToX));
        Assert.True(IsListOfReturnedPrimesWithSundaramCorrectUpTo(upperBound, correctPrimesUpToX));
        Assert.True(IsListOfReturnedPrimesWithAtkinCorrectUpTo(upperBound, correctPrimesUpToX));
    }

    bool IsListOfReturnedPrimesWithEratostheneCorrectUpTo(int upperBound, List<int> correctPrimesUpToX)
    {
        List<int> primes = correctPrimesUpToX.Take(upperBound).ToList();

        PrimeNumberCalculator calc = new PrimeNumberCalculator();
        List<int> actual = calc.ComputePrimesWithSieveOfEratosthenes(upperBound);
        
        return primes.Except(actual).Any() == false && primes.Count == actual.Count;
    }
    
    bool IsListOfReturnedPrimesWithSundaramCorrectUpTo(int upperBound, List<int> correctPrimesUpToX)
    {
        List<int> primes = correctPrimesUpToX.Take(upperBound).ToList();

        PrimeNumberCalculator calc = new PrimeNumberCalculator();
        List<int> actual = calc.ComputePrimesWithSieveOfSundaram(upperBound);
        
        return primes.Except(actual).Any() == false && primes.Count == actual.Count;
    }
    
    bool IsListOfReturnedPrimesWithAtkinCorrectUpTo(int upperBound, List<int> correctPrimesUpToX)
    {
        List<int> primes = correctPrimesUpToX.Take(upperBound).ToList();

        PrimeNumberCalculator calc = new PrimeNumberCalculator();
        List<int> actual = calc.ComputePrimesWithSieveOfAtkin(upperBound);
        
        return primes.Except(actual).Any() == false && primes.Count == actual.Count;
    }
}