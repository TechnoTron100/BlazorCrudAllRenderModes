using BlazorCrudDotNet8.Shared.Entity;

namespace BlazorCrudDotNet8.Shared.Services
{
    public interface IGameServices
    {
        Task<List<Game>> GetAllGames();
        Task<Game> AddGame(Game game);
        Task<Game> GetGameById(int Id);
        Task<Game> EditGame(int id, Game game);
        Task<bool> DeleteGame(int id);
    }
}
