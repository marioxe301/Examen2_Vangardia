using System;
using System.Linq;

namespace hotel.rates.Core
{
    public interface IRepository<T>
    {
        T Add(T entity);
        IQueryable<T> All();

        int SaveChanges();
    }
}
