using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace lametsy_server.Controllers;

[ApiController]
[Route("api")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("forecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


    [HttpGet("calculator")]
    public IActionResult GetAddOperation(string opp, float a, float b)
    {
        float result = 0;
        switch (opp)
        {
            case "add":
                {
                    result = a + b;
                    break;
                }
            default:
                return BadRequest("input malformed");
        }
        return Ok(new CalculatorResult
        {
            OperationResult = result
        });
    }
}

public class CalculatorResult
{
    public float OperationResult { get; internal set; }
}