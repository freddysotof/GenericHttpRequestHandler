
using DotNetCore_GenericHttpHandler.Models;
using GenericHttpHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetCore_GenericHttpHandler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HttpHandlerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<HttpHandlerController> _logger;
        private readonly HttpClient _httpClient;
        public HttpHandlerController(ILogger<HttpHandlerController> logger,IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("TestApi");
        }

        [ProducesResponseType(typeof(ResponseHandler<object>), StatusCodes.Status200OK)]
        [HttpGet("ConsumeRandomApi")]
        public async Task<IActionResult> ConsumeRandomApi()
        {
            var result = await RequestHandler<object, CatFact>.GetFromJsonAsync(_httpClient, "?max_length=5");
            return ResponseHandler<CatFact>.Ok(result.Data);
        }

        [ProducesResponseType(typeof(ResponseHandler<WeatherForecast>), StatusCodes.Status200OK)]
        [HttpGet("OkResult")]
        public IActionResult OKResult()
        {
            var rng = new Random();
            var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return ResponseHandler<WeatherForecast>.Ok(array[0]);
        }

        [ProducesResponseType(typeof(ResponseHandler<WeatherForecast>), StatusCodes.Status400BadRequest)]
        [HttpGet("BadRequestResult")]
        public IActionResult BadRequestResult()
        {
            var rng = new Random();
            var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return ResponseHandler<WeatherForecast>.BadRequest(array[0], "400", "Error 400");
        }

        [ProducesResponseType(typeof(ResponseHandler<WeatherForecast>), StatusCodes.Status204NoContent)]
        [HttpGet("NoContentResult")]
        public IActionResult NoContentResult()
        {
            var rng = new Random();
            var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return ResponseHandler<WeatherForecast>.NoContent();
        }

        [ProducesResponseType(typeof(ResponseHandler<WeatherForecast>), StatusCodes.Status404NotFound)]
        [HttpGet("NotFoundResult")]
        public IActionResult NotFoundResult()
        {
            var rng = new Random();
            var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return ResponseHandler<WeatherForecast>.NotFound(array[0], "404", "Error 404");
        }

        [ProducesResponseType(typeof(ResponseHandler<WeatherForecast>), StatusCodes.Status401Unauthorized)]
        [HttpGet("UnauthorizedResult")]
        public IActionResult UnauthorizedResult()
        {
            var rng = new Random();
            var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return ResponseHandler<WeatherForecast>.Unauthorized();
        }

        [ProducesResponseType(typeof(ResponseHandler<WeatherForecast>), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("UnProcessableEntityResult")]
        public IActionResult UnProcessableEntityResult()
        {
            var rng = new Random();
            var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return ResponseHandler<WeatherForecast>.UnprocessableEntity(array[0], "422", "Unprocessable Entity");
        }

        [ProducesResponseType(typeof(ResponseHandler<WeatherForecast>), StatusCodes.Status500InternalServerError)]
        [HttpGet("InternalServerResult")]
        public IActionResult InternalServerResult()
        {
            var rng = new Random();
            var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return ResponseHandler<WeatherForecast>.InternalServerError("500", "Internal Server Error");
        }
    }
}
