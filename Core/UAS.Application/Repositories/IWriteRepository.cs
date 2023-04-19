using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UAS.Domain.Entities.Common;

namespace UAS.Application.Repositories
{
    public interface IWriteRepository<T,TKey> : IRepository<T,TKey> where T : BaseEntity<TKey>
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T datas);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        Task<bool> RemoveAsync(int id);
        Task<bool> RemoveAsync(Guid id);
        bool Update(T model);

        Task<int> SaveAsync();
    }
}
