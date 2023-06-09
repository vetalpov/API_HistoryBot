using API_test_1.Clients;
using API_test_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_test_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricalEventsController : ControllerBase
    {
        private readonly ILogger<HistoricalEventsController> _logger;


        public HistoricalEventsController(ILogger<HistoricalEventsController> logger)
        {
            _logger = logger;

        }

        [HttpGet(Name = "HistoricalEvents")]
        public async Task<ActionResult<IEnumerable<HistoricalEvents>>> GetHistoricalEventsAsync(string text, int year)
        {
            try
            {
                return HistoricalEventsClient.GetHistoricalEventsAsync(text, year).Result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
