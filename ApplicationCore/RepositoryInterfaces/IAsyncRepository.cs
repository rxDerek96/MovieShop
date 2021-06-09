using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T:class
    {
        Task <T> GetById(int id);
        Task<IEnumerable<T>> ListAll();

        Task<IEnumerable<T>> List(Expression<Func<T,bool>> filter);

        Task<int> GetCount(Expression<Func<T, bool>> filter);

        Task<bool> GetExists(Expression<Func<T, bool>> filter);

        Task<T> add(T entity);

        Task<T> update(T entity);

        Task Delete(T entity);
    }
}
