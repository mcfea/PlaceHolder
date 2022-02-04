using System;
using System.Net.Http;
using PlaceHolderProject.Repositories.Posts;
using PlaceHolderProject.Repositories.Users;

namespace PlaceHolderProject.Repositories.Factories
{
    public static class UserRepositoryFactory
    {
        public static IUserRepository GetRepository()
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
            return new HttpUserRepository(client);
        }
    }
    public static class PostRepositoryFactory
    {
        public static IPostRepository GetRepository()
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
            return new HttpPostRepository(client);
        }
    }
}