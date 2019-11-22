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
    }
}
