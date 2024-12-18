using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Controllers;

public class Test {
    public int id {get; set;}
    public string name {get; set;}
}

[ApiController]
[Route("[controller]")]
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

    [HttpGet("", Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("test", Name = "GetTest")]
    public IEnumerable<Test> Test()
    {
      // Connexion à la base de données mssql VincentDB
      using (SqlConnection connection = new SqlConnection("Server=localhost;Database=VincentDB;User Id=sa;Password=P@ssw0rd;")) {
        connection.Open();
        using (SqlCommand command = new SqlCommand("SELECT id,name FROM table_test", connection)) {
          using (SqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) {
              yield return new Test
              {
                  id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                  name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
              };
            }
          }
        }
      }
    }
}
