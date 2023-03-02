using System.Diagnostics;

public static class ApiActivitySource
{
    public static ActivitySource Instance { get; } = new ActivitySource("DisApi");
}