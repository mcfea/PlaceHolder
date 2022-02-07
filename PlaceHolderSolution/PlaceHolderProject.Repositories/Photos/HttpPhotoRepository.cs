using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using PlaceHolderProject.Repositories.JsonHelpers;

namespace PlaceHolderProject.Repositories.Photos
{
    internal class HttpPhotoRepository : IPhotoRepository
    {
        private const string Target = "Photos";
        private readonly HttpClient _client;

        public HttpPhotoRepository(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public IEnumerable<Photo> GetAll()
        {
            var response = _client.GetStringAsync(Target).Result;

            return JsonConvert.DeserializeObject<List<Photo>>(response);
        }

        public Photo GetById(int photoId)
        {
            var response = _client.GetStringAsync($"{Target}/{photoId}").Result;
            
            return JsonConvert.DeserializeObject<Photo>(response);
        }

        public void Insert(Photo photo)
        {
            var content = photo.GetStringContentFor();

            var result = _client.PostAsync(Target, content).Result;

            result.EnsureSuccessStatusCode();
        }

        public void Delete(int photoId)
        {
            var result = _client.DeleteAsync($"{Target}/{photoId}").Result;

            result.EnsureSuccessStatusCode();
        }

        public void Update(Photo photo)
        {
            var content = photo.GetStringContentFor();
            var result = _client.PutAsync($"{Target}/{photo.Id}", content).Result;
            result.EnsureSuccessStatusCode();
        }

        public IEnumerable<Photo> GetPhotosByAlbumId(int albumId)
        {
            var response = _client.GetStringAsync($"albums/{albumId}/{Target}").Result;

            return JsonConvert.DeserializeObject<List<Photo>>(response);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}