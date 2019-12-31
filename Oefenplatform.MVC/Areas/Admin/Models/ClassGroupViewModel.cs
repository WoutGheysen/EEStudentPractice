using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Admin.Models
{
    public class ClassGroupViewModel
    {
        public ICollection<ClassGroup> classGroups { get; set; }
    }
}
