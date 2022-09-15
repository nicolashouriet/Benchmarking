namespace Compute.Lib;

public class PiApproximator
{
    private record Point(double X, double Y);

    private readonly Random _random = new Random();
    
    public double ApproximatePiUsingMonteCarlo(int numberOfPoints)
    {
        Point[] points = new Point[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            Point p = new Point(_random.NextDouble(), _random.NextDouble());
            points[i] = p;
        }

        double isInsideCount = 0;
        for (int i = 0; i < points.LongLength - 1; i++)
        {
            Point p = points[i];
            if (Math.Sqrt(p.X * p.X + p.Y * p.Y) < 1)
            {
                isInsideCount++;
            }
        }

        double piApproximation = 4.0 * (isInsideCount / points.LongLength);
        return piApproximation;
    }
}