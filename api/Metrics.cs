using App.Metrics;
using App.Metrics.Gauge;
using OpenTelemetry.Metrics;
using Prometheus;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace api
{
    public static class Metric1
    {
        public static Meter m = new Meter("MovieApi");

        public static Counter<int> ApiCalls = m.CreateCounter<int>("api calls");
        public static Counter<int> MoviesCalls = m.CreateCounter<int>("movie calls");
    }

    public static class Histogram1
    {
        public static Meter met = new Meter("MovieHistogram");

        public static Histogram<int> ResponseSizeTrending = met.CreateHistogram<int>("response size");

    }

    public static class UpDownCounter
    {
        public static Meter m = new Meter("MovieUpDownCounter");

        public static UpDownCounter<int> MoviesVsTV = m.CreateUpDownCounter<int>("Movies selected it goes up and tv selected it goes down");
    }


}
