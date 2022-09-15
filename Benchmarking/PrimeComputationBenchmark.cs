using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Compute.Lib;

namespace Benchmarking;

[SimpleJob(RuntimeMoniker.Net60)]
[RPlotExporter]
public class PrimeComputationBenchmark
{
    private PrimeNumberCalculator primeCalculator = new PrimeNumberCalculator();

    [Params(100_000)]
    public int N;

    [Benchmark]
    public List<int> Eratosthene() => primeCalculator.ComputePrimesWithSieveOfEratosthenes(N);

    [Benchmark]
    public List<int> Sundaram() => primeCalculator.ComputePrimesWithSieveOfSundaram(N);
    
    [Benchmark]
    public List<int> Atkin() => primeCalculator.ComputePrimesWithSieveOfAtkin(N);
}