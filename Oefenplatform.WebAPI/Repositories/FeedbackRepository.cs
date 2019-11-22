using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Data;
using Oefenplatform.WebAPI.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.WebAPI.Repositories
{
    public class FeedbackRepository : RepositoryBase<Feedback>
    {
        public FeedbackRepository(OefenplatformContext oefenplatformContext) : base(oefenplatformContext)
        {

        }
    }
}
