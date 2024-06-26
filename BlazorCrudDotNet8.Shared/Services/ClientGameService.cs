﻿using BlazorCrudDotNet8.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudDotNet8.Shared.Services
{
    public class ClientGameService(HttpClient httpClient) : IGameServices
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<Game> AddGame(Game game)
        {
            var result = await _httpClient
                .PostAsJsonAsync("/api/Game", game);
            return await result.Content.ReadFromJsonAsync<Game>();
        }

        public async Task<bool> DeleteGame(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/game");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<Game> EditGame(int id, Game game)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/game/{id}", game);
            return await result.Content.ReadFromJsonAsync<Game>();
        }

        public Task<List<Game>> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetGameById(int Id)
        {
            var result = await _httpClient
                .GetFromJsonAsync<Game>($"/api/game/{Id}");
            return result!;
        }
    }
}
