using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Api.Data.Context;
using src.Api.Domain.Entities;
using src.Api.Domain.Interfaces;

namespace src.Api.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> FindByIdAsync(Guid id)
        {
            try
            {
                return await _dataset.FirstOrDefaultAsync(u => u.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            if (item == null) return null;

            if (item.Id == Guid.Empty) item.Id = Guid.NewGuid();

            item.CreateAt = DateTime.Now;
            item.UpdateAt = null;

            try
            {
                _dataset.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            if (item == null) return null;

            try
            {
                var result = await _dataset.SingleOrDefaultAsync(u => u.Id.Equals(item.Id));

                if (result == null) return null;

                item.UpdateAt = DateTime.Now;
                item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.FirstOrDefaultAsync(u => u.Id.Equals(id));

                if (result == null) return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dataset.AnyAsync(u => u.Id.Equals(id));
        }
    }
}
