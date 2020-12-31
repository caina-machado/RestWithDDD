using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Api.Domain.Entities;

namespace src.Api.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindByIdAsync(Guid id);
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
