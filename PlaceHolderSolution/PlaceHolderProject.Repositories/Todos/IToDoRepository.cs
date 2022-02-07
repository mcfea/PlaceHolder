using System.Collections.Generic;
using PlaceHolderProject.Repositories.Repositories;

namespace PlaceHolderProject.Repositories.Todos
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        IEnumerable<ToDo> GetToDosByUserId(int userId);
    }
}