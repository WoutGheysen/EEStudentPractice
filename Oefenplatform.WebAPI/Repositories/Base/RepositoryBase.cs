using Microsoft.EntityFrameworkCore;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.WebAPI.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase<int>
    {
        protected readonly OefenplatformContext _oefenplatformContext;

        public RepositoryBase(OefenplatformContext studentServiceContext)
        {
            _oefenplatformContext = studentServiceContext;
        }


        public async Task<T> Add(T entity)
        {
            _oefenplatformContext.Set<T>().Add(entity);
            try
            {
                await _oefenplatformContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _oefenplatformContext.Set<T>().Remove(entity);
            try
            {
                await _oefenplatformContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return null;
            }
            return await Delete(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _oefenplatformContext.Set<T>().AsNoTracking();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _oefenplatformContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _oefenplatformContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _oefenplatformContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }
    }
}
