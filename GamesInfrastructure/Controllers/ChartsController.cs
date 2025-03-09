using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GamesInfrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController(Istp1Context context) : ControllerBase
    {
        private sealed record CountGamesByPublisher(string Publisher, int Count);

        private sealed record RateForGame(string Game, double Rating);

        private readonly Istp1Context context = context;

        [HttpGet("countGamesByPublisher")]
        public async Task<JsonResult> GetCountGamesByPublisher(CancellationToken cancellationToken)
        {
            var responseItems = await context.Games
                .GroupBy(game => game.PublisherId)
                .Select(g => new CountGamesByPublisher(
                    context.Publishers.Where(p => p.Id == g.Key).Single().Name,
                    g.Count()))
                .ToArrayAsync(cancellationToken);

            return new JsonResult(responseItems);
        }

        [HttpGet("rateForGame")]
        public async Task<JsonResult> GetRatingForGames(CancellationToken cancellationToken)
        {
            var responseItems = await context.Games
                .GroupJoin(
                    context.Reviews,
                    ga => ga.Id,
                    re => re.GameId,
                    (ga, reviews) => new { ga.Name, Ratings = reviews.Select(r => r.Rating) }
                )
                .Select(g => new RateForGame(
                    g.Name,
                    g.Ratings.Any() ? g.Ratings.Average() : 0
                ))
                .ToArrayAsync(cancellationToken);


            return new JsonResult(responseItems);
        }
    }
}
