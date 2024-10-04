using LearningHub.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        [HttpGet("weather/{city}")]
        public async Task<Weather> City(string city)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=f3fb5f7e94a858215d2544eead09240b");
                var stringResult = await response.Content.ReadAsStringAsync();
                var weatherResult = JsonConvert.DeserializeObject<Weather>(stringResult);
                return weatherResult;
            }
        }
    }
}
