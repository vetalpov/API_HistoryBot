using API_test_1.Clients;
using API_test_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_test_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseDateHistoryController : ControllerBase
    {
        private readonly DatabaseDateHistoryClients _database;

        public DatabaseDateHistoryController()
        {
            _database = new DatabaseDateHistoryClients();
        }
        [HttpPost]
        public async Task<IActionResult> AddDatehistory([FromBody] Datehistory datehistory)
        {
            try
            {
                await _database.InsertDateHistoryAsync(datehistory);
                return Ok("Recipe added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Datehistory>>> GetDatehistoryById(long userId)
        {
            try
            {
                var recipes = await _database.SelectDateHistoryAsync(userId);
                if (recipes.Count > 0)
                {
                    return Ok(recipes);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteDatehistoryByDateAndId(string date, long userId)
        {
            try
            {
                await _database.DeleteDateHistoryByDateAndUserIdAsync(date, userId);
                return Ok("Recipe deleted successfully.");
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "An error occurred while deleting the recipe.");
            }
        }

        [HttpPut("datehistory/{userId}")]
        public async Task<IActionResult> UpdateDatehistoryByIdAndDate(long userId, [FromBody] Datehistory datehistory)
        {
            try
            {
                await _database.UpdateDateHistoryByIdAndDateAsync( datehistory.Date, userId,  datehistory);
                return Ok("Рецепт успішно оновлено.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Помилка при оновленні рецепту: {ex.Message}");
            }
        }


        [HttpGet("{userId}/{date}")]
        public async Task<ActionResult<Datehistory>> GetDatehistoryById(long userId, string date)
        {
            try
            {
                var recipe = await _database.GetDateHistoryByIdAndDateAsync(userId, date);
                if (recipe != null)
                {
                    return Ok(recipe);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }      
    }
}
