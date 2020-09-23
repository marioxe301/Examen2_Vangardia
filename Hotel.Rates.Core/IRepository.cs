using System;
using System.Linq;

namespace Hotel.Rates.Core
{
    public interface IRepository<T>
    {
        T Add(T entity);
        IQueryable<T> All();

        int SaveChanges();
    }
}
