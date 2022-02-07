using System;
using System.Net.Http;
using PlaceHolderProject.Repositories.Albums;
using PlaceHolderProject.Repositories.Comments;
using PlaceHolderProject.Repositories.Photos;
using PlaceHolderProject.Repositories.Posts;
using PlaceHolderProject.Repositories.Todos;
using PlaceHolderProject.Repositories.ToDos;
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
    public static class CommentRepositoryFactory
    {
        public static ICommentRepository GetRepository()
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
            return new HttpCommentRepository(client);
        }
    }
    public static class AlbumRepositoryFactory
    {
        public static IAlbumRepository GetRepository()
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
            return new HttpAlbumRepository(client);
        }
    }
    public static class PhotoRepositoryFactory
    {
        public static IPhotoRepository GetRepository()
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
            return new HttpPhotoRepository(client);
        }
    }
    public static class ToDoRepositoryFactory
    {
        public static IToDoRepository GetRepository()
        {
            var client = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
            return new HttpToDoRepository(client);
        }
    }
}