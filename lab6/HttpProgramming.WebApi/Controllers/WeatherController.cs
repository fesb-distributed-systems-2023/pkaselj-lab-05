using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpProgramming.WebApi.Controllers
{
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        [Route("/temperature")]
        public IActionResult GetTemperature()
        {
            return Ok("13.5C");
        }

        [HttpGet]
        [Route("/temperature/{city}")]
        public IActionResult GetTemperature([FromRoute] string city)
        {
            if (city == "Split")
            {
                return Ok("Temperatura u Splitu je 40 C");
            }
            else if (city == "Zagreb")
            {
                return Ok("Temperatura u Zagrebu je -20C");
            }
            else
            {
                return NotFound($"Nepoznati grad: {city}");
            }
        }

        [HttpGet]
        [Route("/transfer/{client1}/{client2}/{amount}")]
        public IActionResult MakeTransaction(
            [FromRoute] string client1,
            [FromRoute] string client2,
            [FromRoute] int amount
        )
        {
            return Ok($"Client {client1} transfered {amount}$ to client {client2}.");
        }

    }
}
