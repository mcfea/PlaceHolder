using System;
using System.Collections.Generic;

namespace PlaceHolderProject.Repositories.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetById(int postId);
        void Insert(T post);
        void Delete(int postId);
        void Update(T post);
    }
}