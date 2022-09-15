using BenchmarkDotNet.Running;
using Benchmarking;
using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;

//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
BenchmarkSwitcher.FromTypes(new Type[] { typeof(PrimeComputationBenchmark)}).RunAll();
