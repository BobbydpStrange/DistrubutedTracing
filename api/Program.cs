using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OpenTelemetry.Resources;
using OpenTelemetry;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using api;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5050") });


using var traceProvider = Sdk.CreateTracerProviderBuilder()
 .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("DisApi"))
 .AddSource(ApiActivitySource.Instance.Name)
 .AddJaegerExporter(o =>
 {
     o.Protocol = OpenTelemetry.Exporter.JaegerExportProtocol.HttpBinaryThrift;
     //o.Endpoint = new Uri("http://jaeger:14268/api/traces");
 })
 .AddHttpClientInstrumentation()
 .AddAspNetCoreInstrumentation()
 .Build();

/*using var meterProvider = Sdk.CreateMeterProviderBuilder()
    .AddMeter(Metric1.m.Name)
    .AddMeter(Histogram1.met.Name)
    .AddMeter(UpDownCounter.m.Name)
    //.AddRuntimeInstrumentation()
    //.AddProcessInstrumentation()
    .AddPrometheusExporter(o =>
    {
        o.StartHttpListener = true;
        o.HttpListenerPrefixes = new string[] { $"http://localhost:9184" };
    })
    .Build();*/



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
