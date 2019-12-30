using Microsoft.EntityFrameworkCore;
using Oefenplatform.WebAPI.Data;
using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.WebAPI.Repositories
{
    public class SchoolUserRepository
    {
        protected readonly OefenplatformContext _oefenplatformContext;
        public SchoolUserRepository(OefenplatformContext oefenplatformContext) 
        {
            _oefenplatformContext = oefenplatformContext;
        }

        public async Task<SchoolUser> Add(SchoolUser entity)
        {
            //_oefenplatformContext.Add(entity);
            _oefenplatformContext.Set<SchoolUser>().Add(entity); //Use this Set or just Add?
            try
            {
                await _oefenplatformContext.SaveChangesAsync();
            }
            catch
            {
                Console.WriteLine("Test failed");
                return null; //tests resolve into this
            }
            return entity;
        }

        public async Task<SchoolUser> Delete(SchoolUser entity)
        {
            _oefenplatformContext.Set<SchoolUser>().Remove(entity);
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

        public async Task<SchoolUser> Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return null;
            }
            return await Delete(entity);
        }

        public IQueryable<SchoolUser> GetAll()
        {
            return _oefenplatformContext.Set<SchoolUser>().AsNoTracking().Include(u => u.SchoolUserCategory).Include(u => u.ClassGroup);
        }

        public virtual async Task<SchoolUser> GetByIdentityReference(string id)
        {
            return await _oefenplatformContext.Set<SchoolUser>().Where(u => u.IdentityReference == id)
                .Include(u => u.SchoolUserCategory).Include(u => u.ClassGroup)
                .FirstOrDefaultAsync();
        }

        public virtual async Task<SchoolUser> GetById(Guid id)
        {
            return await _oefenplatformContext.Set<SchoolUser>().Include(u => u.SchoolUserCategory).Include(u => u.ClassGroup).Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SchoolUser>> ListAll()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<SchoolUser> Update(SchoolUser entity)
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
