using System.Diagnostics;

public static class MovieActivitySource
{
    public static ActivitySource Instance { get; } = new ActivitySource("DisWeb");
}