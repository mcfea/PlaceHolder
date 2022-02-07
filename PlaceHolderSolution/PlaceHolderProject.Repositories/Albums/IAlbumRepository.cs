using System.Collections.Generic;
using PlaceHolderProject.Repositories.Repositories;

namespace PlaceHolderProject.Repositories.Albums
{
    public interface IAlbumRepository : IRepository<Album>
    {
        IEnumerable<Album> GetAlbumsByUserId(int userId);
    }
}