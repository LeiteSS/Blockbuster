using System.Collections.Generic;

namespace blockbuster.Repository
{
    public interface IRepository<T>
    {
        List<T> ListAll();

         T FindById(int id);

         void Create(T entity);

         void Delete(int id);

         void Update(int id, T entity);

         int NextId();
    }
}