using DistrubutedTracing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OpenTelemetry.Resources;
using OpenTelemetry;
using OpenTelemetry.Trace;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

using var traceProvider = Sdk.CreateTracerProviderBuilder()
 .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("DisWeb"))
 .AddSource(MovieActivitySource.Instance.Name)
 .AddJaegerExporter(o =>
 {
     o.Protocol = OpenTelemetry.Exporter.JaegerExportProtocol.HttpBinaryThrift;
     //o.Endpoint = new Uri("http://jaeger:14268/api/traces");
 })
 .AddHttpClientInstrumentation()
 //.AddAspNetCoreInstrumentation()
 .Build();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


await builder.Build().RunAsync();
