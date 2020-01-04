using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Admin.Models
{
    public class UserViewModel
    {
        public ICollection<SchoolUser> Users { get; set; }
        public ICollection<ClassGroup> ClassGroups { get; set; }
        public ICollection<SchoolUserCategory> Categories { get; set; }
    }
}
