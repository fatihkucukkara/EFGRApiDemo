using System.Collections.Generic;
using System.Linq;

namespace EFGRApiDemo.Dal.Base.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int Id);
        int Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
