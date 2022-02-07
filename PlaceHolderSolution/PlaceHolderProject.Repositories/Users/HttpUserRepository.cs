using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using PlaceHolderProject.Repositories.JsonHelpers;
using PlaceHolderProject.Repositories.Posts;

namespace PlaceHolderProject.Repositories.Users
{
    internal class HttpUserRepository : IUserRepository
    {
        private const string Target = "users";
        private readonly HttpClient _client;

        public HttpUserRepository(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public IEnumerable<User> GetAll()
        {
            var response = _client.GetStringAsync(Target).Result;

            return JsonConvert.DeserializeObject<List<User>>(response);
        }

        public User GetById(int userId)
        {
            var response = _client.GetStringAsync($"{Target}/{userId}").Result;
            
            return JsonConvert.DeserializeObject<User>(response);
        }

        public void Insert(User user)
        {
            var content = user.GetStringContentFor();

            var result = _client.PostAsync(Target, content).Result;

            result.EnsureSuccessStatusCode();
        }

        public void Delete(int userId)
        {
            var result = _client.DeleteAsync($"{Target}/{userId}").Result;

            result.EnsureSuccessStatusCode();
        }

        public void Update(User user)
        {
            var content = user.GetStringContentFor();
            var result = _client.PutAsync($"{Target}/{user.Id}", content).Result;
            result.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}