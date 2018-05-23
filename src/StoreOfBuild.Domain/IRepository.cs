namespace StoreOfBuild.Domain
{
    public interface IRepository<T>
    {
         T GetId(int Id);   
         void Save(T entity);
    }
}