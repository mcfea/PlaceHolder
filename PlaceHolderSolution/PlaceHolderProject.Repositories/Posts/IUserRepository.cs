using System;
using System.Collections.Generic;
using PlaceHolderProject.Repositories.Posts;

namespace PlaceHolderProject.Repositories.Users
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int userId);
        IEnumerable<Post> GetUserPostsByUserId(int userId);
        void InsertUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
    }
}