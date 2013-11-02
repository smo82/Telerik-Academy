using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Services.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Get(int id);

        IQueryable<T> GetConstraint(Expression<Func<T, bool>> searchRule);

        void Add(T item);

        void Delete(int id);

        void Update(int id, T item);
    }
}
