using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using PlaceHolderProject.Repositories.JsonHelpers;

namespace PlaceHolderProject.Repositories.Posts
{
    internal class HttpPostRepository : IPostRepository
    {
        private const string Target = "posts";
        private readonly HttpClient _client;

        public HttpPostRepository(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public IEnumerable<Post> GetAll()
        {
            var response = _client.GetStringAsync(Target).Result;

            return JsonConvert.DeserializeObject<List<Post>>(response);
        }

        public Post GetById(int postId)
        {
            var response = _client.GetStringAsync($"{Target}/{postId}").Result;

            return JsonConvert.DeserializeObject<Post>(response);
        }
        
        public void Insert(Post post)
        {
            var content = post.GetStringContentFor();

            var result = _client.PostAsync(Target, content).Result;

            result.EnsureSuccessStatusCode();
        }

        public void Delete(int postId)
        {
            var result = _client.DeleteAsync($"{Target}/{postId}").Result;

            result.EnsureSuccessStatusCode();
        }

        public void Update(Post user)
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