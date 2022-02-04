using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlaceHolderProject.Repositories.Posts;

namespace PlaceHolderProject.Repositories.Users
{
    internal class HttpUserRepository : IUserRepository
    {
        private const string Target = "users";
        private readonly HttpClient _client = new HttpClient(){BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
        
        public IEnumerable<User> GetUsers()
        {
            var response = _client.GetStringAsync(Target).Result;

            return JsonConvert.DeserializeObject<List<User>>(response);
        }

        public User GetUserById(int userId)
        {
            var response = _client.GetStringAsync($"{Target}/{userId}").Result;
            
            return JsonConvert.DeserializeObject<User>(response);
        }

        public IEnumerable<Post> GetUserPostsByUserId(int userId)
        {
            var response = _client.GetStringAsync($"{Target}/{userId}/posts").Result;

            return JsonConvert.DeserializeObject<List<Post>>(response);
        }

        public void InsertUser(User user)
        {
            var content = GetStringContentFor(user);

            var result = _client.PostAsync(Target, content).Result;

            result.EnsureSuccessStatusCode();
        }

        public void DeleteUser(int userId)
        {
            var result = _client.DeleteAsync($"{Target}/{userId}").Result;

            result.EnsureSuccessStatusCode();
        }

        public void UpdateUser(User user)
        {
            var content = GetStringContentFor(user);
            var result = _client.PutAsync($"{Target}/{user.Id}", content).Result;
            result.EnsureSuccessStatusCode();
        }

        private static StringContent GetStringContentFor(User user)
        {
            var userJson = JsonConvert.SerializeObject(user);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");
            return content;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}