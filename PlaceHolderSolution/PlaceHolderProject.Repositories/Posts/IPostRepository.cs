using System.Collections.Generic;
using PlaceHolderProject.Repositories.Repositories;

namespace PlaceHolderProject.Repositories.Posts
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostsByUserId(int userId);
    }
}