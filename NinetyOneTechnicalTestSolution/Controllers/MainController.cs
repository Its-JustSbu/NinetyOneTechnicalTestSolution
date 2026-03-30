using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NinetyOneTechnicalTestSolution.Models.DTOs;
using NinetyOneTechnicalTestSolution.Repositories;

namespace NinetyOneTechnicalTestSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IRepository _repository; 
        public MainController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Main
        [HttpGet("GetAllScores")]
        public async Task<IActionResult> GetAllScores()
        {
            try
            {
                var scores = await _repository.GetAllAsync<Scores>();

                if (scores.Count == 0) return NotFound("No Top Scores Found");

                return Ok(scores);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
                throw;
            }
        }
    }
}
