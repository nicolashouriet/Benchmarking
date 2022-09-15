using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Compute.Lib;

namespace Benchmarking;

[SimpleJob(RuntimeMoniker.Net60)]
[RPlotExporter]
public class PiApproximationBenchmark
{
    private PiApproximator _piApproximator = new PiApproximator();

    [Params(100_000, 100_000_000)]
    public int N;

    [Benchmark]
    public double MonteCarlo() => _piApproximator.ApproximatePiUsingMonteCarlo(N);
}