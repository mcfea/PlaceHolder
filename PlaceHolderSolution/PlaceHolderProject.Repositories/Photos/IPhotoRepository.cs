using System.Collections.Generic;
using PlaceHolderProject.Repositories.Repositories;

namespace PlaceHolderProject.Repositories.Photos
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        IEnumerable<Photo> GetPhotosByAlbumId(int albumId);
    }
}