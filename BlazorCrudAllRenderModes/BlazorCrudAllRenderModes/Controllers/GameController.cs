using BlazorCrudDotNet8.Shared.Entity;
using BlazorCrudDotNet8.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudAllRenderModes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(IGameServices gameServices) : ControllerBase
    {
        private readonly IGameServices _services = gameServices;

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameById(int id)
        {
            var game = await _services.GetGameById(id);
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            var newGame = await _services.AddGame(game);
            return Ok(newGame);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> EditGame(int id, Game game)
        {
            var newGame = await _services.EditGame(id, game);
            return Ok(newGame);
        }

        [HttpDelete("{int}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var game = await _services.DeleteGame(id);
            return Ok(game);
        }
    }
}
