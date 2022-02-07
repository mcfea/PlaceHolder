using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using PlaceHolderProject.Repositories.JsonHelpers;

namespace PlaceHolderProject.Repositories.Comments
{
    internal class HttpCommentRepository : ICommentRepository
    {
        private const string Target = "comments";
        private readonly HttpClient _client;

        public HttpCommentRepository(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public IEnumerable<Comment> GetAll()
        {
            var response = _client.GetStringAsync(Target).Result;

            return JsonConvert.DeserializeObject<List<Comment>>(response);
        }

        public Comment GetById(int commentId)
        {
            var response = _client.GetStringAsync($"{Target}/{commentId}").Result;
            
            return JsonConvert.DeserializeObject<Comment>(response);
        }

        public void Insert(Comment comment)
        {
            var content = comment.GetStringContentFor();

            var result = _client.PostAsync(Target, content).Result;

            result.EnsureSuccessStatusCode();
        }

        public void Delete(int commentId)
        {
            var result = _client.DeleteAsync($"{Target}/{commentId}").Result;

            result.EnsureSuccessStatusCode();
        }

        public void Update(Comment comment)
        {
            var content = comment.GetStringContentFor();
            var result = _client.PutAsync($"{Target}/{comment.Id}", content).Result;
            result.EnsureSuccessStatusCode();
        }

        public IEnumerable<Comment> GetCommentsByPostId(int postId)
        {
            var response = _client.GetStringAsync($"posts/{postId}/{Target}").Result;

            return JsonConvert.DeserializeObject<List<Comment>>(response);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}