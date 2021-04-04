using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface IRepository<T>
    {

        public IEnumerable<T> FindAll();

        public void Create(T entity);
        
        public T FindById(long id);

        public void Update(long id, T entity);

        public void DeleteById(long id);

        public bool ExistsById(long id);

    }
}