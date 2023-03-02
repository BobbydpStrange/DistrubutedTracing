using System.Diagnostics.Metrics;

namespace api
{
    public static class Metrics
    {
        public static Meter m = new Meter("MovieApi");

        public static Counter<int> ApiCalls = m.CreateCounter<int>("api calls");
        public static Counter<int> MoviesCalls = m.CreateCounter<int>("movie calls");
    }
}
