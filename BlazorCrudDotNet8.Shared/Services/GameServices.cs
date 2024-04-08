using BlazorCrudDotNet8.Shared.Data;
using BlazorCrudDotNet8.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Shared.Services
{
    public class GameServices(DataContext context) : IGameServices
    {
        private readonly DataContext _context = context;

        public async Task<Game> AddGame(Game game)
        {
            _context.Add(game);
            await _context.SaveChangesAsync();

            return game;
        }

        public async Task<bool> DeleteGame(int id)
        {
            var dbGame=await _context.Games.FindAsync(id);
            if(dbGame is not null)
            {
                _context.Remove(dbGame);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Game> EditGame(int id, Game game)
        {
            var dbGame = await _context.Games.FindAsync(id);
            if (dbGame is not null)
            {
                dbGame.Name = game.Name;
                _context.Update(dbGame);
                await _context.SaveChangesAsync();
                return dbGame;
            }
            throw new Exception("Game not found");
        }

        public async Task<List<Game>> GetAllGames()
        {
            await Task.Delay(1000);
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetGameById(int Id)
        {
            return await _context.Games.FindAsync(Id);
        }
    }
}
