using BenchmarkDotNet.Running;
using Benchmarking;
using Compute.Lib;
using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;

//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
//BenchmarkSwitcher.FromTypes(new Type[] { typeof(PrimeComputationBenchmark)}).RunAll();
BenchmarkSwitcher.FromTypes(new Type[] { typeof(PiApproximationBenchmark)}).RunAll();
