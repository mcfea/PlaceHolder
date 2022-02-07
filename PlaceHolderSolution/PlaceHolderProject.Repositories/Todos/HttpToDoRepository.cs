using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using PlaceHolderProject.Repositories.JsonHelpers;
using PlaceHolderProject.Repositories.Todos;

namespace PlaceHolderProject.Repositories.ToDos
{
    internal class HttpToDoRepository : IToDoRepository
    {
        private const string Target = "ToDos";
        private readonly HttpClient _client;

        public HttpToDoRepository(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public IEnumerable<ToDo> GetAll()
        {
            var response = _client.GetStringAsync(Target).Result;

            return JsonConvert.DeserializeObject<List<ToDo>>(response);
        }

        public ToDo GetById(int toDoId)
        {
            var response = _client.GetStringAsync($"{Target}/{toDoId}").Result;
            
            return JsonConvert.DeserializeObject<ToDo>(response);
        }

        public void Insert(ToDo toDo)
        {
            var content = toDo.GetStringContentFor();

            var result = _client.PostAsync(Target, content).Result;

            result.EnsureSuccessStatusCode();
        }

        public void Delete(int toDoId)
        {
            var result = _client.DeleteAsync($"{Target}/{toDoId}").Result;

            result.EnsureSuccessStatusCode();
        }

        public void Update(ToDo toDo)
        {
            var content = toDo.GetStringContentFor();
            var result = _client.PutAsync($"{Target}/{toDo.Id}", content).Result;
            result.EnsureSuccessStatusCode();
        }

        public IEnumerable<ToDo> GetToDosByUserId(int userId)
        {
            var response = _client.GetStringAsync($"users/{userId}/{Target}").Result;

            return JsonConvert.DeserializeObject<List<ToDo>>(response);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}