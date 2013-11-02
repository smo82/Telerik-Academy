using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJewels.Service.Repositories
{
    interface IReporitory<T>
    {
        T Add(T entity);
        T Get(int id);
        IQueryable<T> All();
        void Delete(int id);
        void Update(int id, T entity);
    }
}
