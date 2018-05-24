using System.Collections.Generic;
using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.Domain
{
    public interface IRepository<T>
    {
        T GetId(int Id);
        void Save(T entity);
        IEnumerable<T> GetList();
    }
}