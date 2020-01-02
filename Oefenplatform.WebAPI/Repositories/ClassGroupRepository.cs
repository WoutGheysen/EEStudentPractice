using Microsoft.EntityFrameworkCore;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Data;
using Oefenplatform.WebAPI.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.WebAPI.Repositories
{
    public class ClassGroupRepository : RepositoryBase<ClassGroup>
    {
        public ClassGroupRepository(OefenplatformContext oefenplatformContext) : base(oefenplatformContext)
        {

        }

        public override async Task<ClassGroup> GetById(int id)
        {
            return await _oefenplatformContext.Set<ClassGroup>().Include(u => u.YearGrade).Where(u => u.Id == id).FirstOrDefaultAsync();
        }
    }
}
