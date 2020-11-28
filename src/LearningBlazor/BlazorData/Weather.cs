using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlazorData
{
    public static class Weather
    {
        [FunctionName("GetWeather")]
        public static async Task<IActionResult> GetWeather(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetWeather")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(await Task.Run(() => new WeatherForecast()
            {
                Date = DateTime.UtcNow,
                Summary = $"Test-{DateTime.UtcNow.Ticks}",
                Temperature = new Random().Next(-20, 40)
            }));
        }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int Temperature { get; set; }

        public string Summary { get; set; }
    }
}
