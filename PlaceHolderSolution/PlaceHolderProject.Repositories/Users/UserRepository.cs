using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlaceHolderProject.Repositories.Users
{
    internal class PlaceHolderJsonUserRepository : IUserRepository
    {
        private readonly HttpClient _client = new HttpClient(){BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };

        
        public IEnumerable<User> GetUsers()
        {
            var response = _client.GetStringAsync("users").Result;

            return JsonConvert.DeserializeObject<List<User>>(response);
        }

        public User GetUserById(int userId)
        {
            var response = _client.GetStringAsync($"users/{userId}").Result;

            return JsonConvert.DeserializeObject<User>(response);
        }

        public void InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userID)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}