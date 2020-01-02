using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Admin.Models
{
    public class SchoolUserCategoryViewModel
    {
        public ICollection<SchoolUserCategory> schoolUserCategories { get; set; }
    }
}
