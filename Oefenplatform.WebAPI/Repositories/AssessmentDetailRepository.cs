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
    public class AssessmentDetailRepository : RepositoryBase<AssessmentDetail>
    {
        public AssessmentDetailRepository(OefenplatformContext oefenplatformContext) : base(oefenplatformContext)
        {

        }

        public async Task<AssessmentDetail> GetByIdInclusive(int id)
        {
            return await _oefenplatformContext.AssessmentDetails
                .Where(ad => ad.Id == id)
                .Include(ad => ad.Questions)
                .Include(ad => ad.Assessment)
                .FirstOrDefaultAsync();
        }
    }
}
