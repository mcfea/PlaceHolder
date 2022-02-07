using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using PlaceHolderProject.Repositories.JsonHelpers;

namespace PlaceHolderProject.Repositories.Albums
{
    internal class HttpAlbumRepository : IAlbumRepository
    {
        private const string Target = "albums";
        private readonly HttpClient _client;

        public HttpAlbumRepository(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public IEnumerable<Album> GetAll()
        {
            var response = _client.GetStringAsync(Target).Result;

            return JsonConvert.DeserializeObject<List<Album>>(response);
        }

        public Album GetById(int albumId)
        {
            var response = _client.GetStringAsync($"{Target}/{albumId}").Result;
            
            return JsonConvert.DeserializeObject<Album>(response);
        }

        public void Insert(Album album)
        {
            var content = album.GetStringContentFor();

            var result = _client.PostAsync(Target, content).Result;

            result.EnsureSuccessStatusCode();
        }

        public void Delete(int albumId)
        {
            var result = _client.DeleteAsync($"{Target}/{albumId}").Result;

            result.EnsureSuccessStatusCode();
        }

        public void Update(Album album)
        {
            var content = album.GetStringContentFor();
            var result = _client.PutAsync($"{Target}/{album.Id}", content).Result;
            result.EnsureSuccessStatusCode();
        }

        public IEnumerable<Album> GetAlbumsByUserId(int userId)
        { 
            var response = _client.GetStringAsync($"users/{userId}/{Target}").Result;

            return JsonConvert.DeserializeObject<List<Album>>(response);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}