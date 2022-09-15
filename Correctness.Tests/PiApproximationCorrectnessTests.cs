using Compute.Lib;

namespace Correctness.Tests;

public class PiApproximationCorrectnessTests
{
    [Fact]
    public void PiApproximationViaMonteCarloIsCorrect()
    {
        PiApproximator piApproximator = new PiApproximator();
        double pi1 = piApproximator.ApproximatePiUsingMonteCarlo(100_000);
        double pi5 = piApproximator.ApproximatePiUsingMonteCarlo(100_000_000);

        Assert.InRange(pi1, 3.14, 3.15);
        Assert.InRange(pi5, 3.14, 3.1415);
    }
}