using System.Collections.Generic;
using PlaceHolderProject.Repositories.Repositories;

namespace PlaceHolderProject.Repositories.Comments
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetCommentsByPostId(int postId);
    }
}