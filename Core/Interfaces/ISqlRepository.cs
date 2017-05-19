using System.Collections.Generic;

namespace maeamamuito.Core.Interfaces
{
    public interface ISqlRepository<T> where T : new()
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(int id);
        T FindEntity(int id);
        T FindEntity(string login);
        T Create(T item);
        void Remove(string objectId);
        void Update(string objectId, T entity);
        bool Exists(string objectId);
    }
}