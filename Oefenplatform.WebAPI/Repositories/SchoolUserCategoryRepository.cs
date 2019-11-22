using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Data;
using Oefenplatform.WebAPI.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.WebAPI.Repositories
{
    public class SchoolUserCategoryRepository : RepositoryBase<SchoolUserCategory>
    {
        public SchoolUserCategoryRepository(OefenplatformContext oefenplatformContext) : base(oefenplatformContext)
        {

        }
    }
}
