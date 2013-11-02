using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Get(int id);
        IQueryable<T> All();
    }
}
