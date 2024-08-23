using System.ServiceModel.Channels;
using System.Text;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;
using soaptest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSoapCore();
builder.Services.TryAddSingleton<TestAuditService>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<TestAuditService>(opt =>
    {
        opt.Path = "/test.asmx";
        opt.SoapSerializer = SoapSerializer.XmlSerializer;
    });

    // Add endpoint for NeedAService
    endpoints.UseSoapEndpoint<NeedAService>(opt =>
    {
        opt.Path = "/needservice.asmx"; // Set the desired path
        opt.EncoderOptions = new[] {
					new SoapEncoderOptions() { MessageVersion = MessageVersion.Soap12WSAddressing10}
				};
        opt.SoapSerializer = SoapSerializer.XmlSerializer;
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
