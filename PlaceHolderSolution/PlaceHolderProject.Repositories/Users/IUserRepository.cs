using System;
using System.Collections.Generic;
using PlaceHolderProject.Repositories.Posts;
using PlaceHolderProject.Repositories.Repositories;

namespace PlaceHolderProject.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<Post> GetUserPostsByUserId(int userId);
    }
}