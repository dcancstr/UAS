using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using UAS.Domain.Entities.Common;

namespace UAS.Application.Repositories
{
    public interface IReadRepository<T, TKey> : IRepository<T,TKey> where T : BaseEntity<TKey>
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(int id, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
        Task<T> GetByIdAsync(Guid id, bool tracking = true);
    }
}
