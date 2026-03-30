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
        //GET: api/Main/TopScorers
        [HttpGet("GetTopScorers")]
        public async Task<IActionResult> GetTopScorers()
        {
            try
            {
                var scores = await _repository.GetAllAsync<Scores>();
                var maxScore = scores.Max(s => s.Score);
                var scorers = scores.Where(s => s.Score == maxScore)
                    .OrderBy(scorer => scorer.FirstName)
                    .ThenBy(scorer => scorer.LastName)
                    .ToList();

                if (scorers.Count == 0) return NotFound("No Top Scorers Found");

                return Ok(scorers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
                throw;
            }
        }
    }
}
