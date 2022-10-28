using Microsoft.AspNetCore.Mvc;

namespace webapiexercise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private  static List<WeatherForecast> ListWeatherForecast =new();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if(ListWeatherForecast==null || !ListWeatherForecast.Any()){
              ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                 Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet]
    public IActionResult Get()
    {   
        _logger.LogDebug("retornando la lista de watherforecast");
        return Ok(ListWeatherForecast);
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weather){
        ListWeatherForecast.Add(weather);
        return Ok();
    }

    [HttpDelete("{index}")]
       public IActionResult Delete(int index){
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}
