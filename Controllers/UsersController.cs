using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Services;
using UserManagementAPI.DataAccess;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly RandomUserService _randomUserService;
        private readonly UserRepository _userRepository;

        public UsersController(RandomUserService randomUserService, UserRepository userRepository)
        {
            _randomUserService = randomUserService;
            _userRepository = userRepository;
        }

        [HttpGet("populate")]
        public async Task<IActionResult> Populate(int count = 10)
        {
            if (count < 1 || count > 100)
            {
                return BadRequest("Count must be between 1 and 100.");
            }
            
            var users = await _randomUserService.FetchRandomUserAsync(count);
            await _userRepository.SaveUsersAsync(users);

            return Ok(new { message = $"{users.Count} Users Saved Successfully!"});
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] string? country = null)
        {
            try
            {
                var users = await _userRepository.GetUsersAsync(country);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("metrics")]
        public async Task<IActionResult> GetMetrics()
        {
            var metrics = await _userRepository.GetMetricsAsync();
            return Ok(metrics);
        }
    }
}