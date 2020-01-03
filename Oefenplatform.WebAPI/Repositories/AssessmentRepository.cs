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
    public class AssessmentRepository : RepositoryBase<Assessment>
    {
        public AssessmentRepository(OefenplatformContext oefenplatformContext):base (oefenplatformContext)
        {

        }

        public async Task<Assessment> GetIdInclusive(int id)
        {
            return await _oefenplatformContext.Assessment
                .Where(q => q.Id == id)
                .Include(a => a.AssessmentDetails)
                .FirstOrDefaultAsync();
        }
    }
}
