using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.Lib.Models
{
    public class CourseCategory : EntityBase<int>
    {
        [Required(ErrorMessage = "Gelieve een vaknaam in te geven.")]
        public string Category { get; set; }
        public ICollection<Assessment> Assessments { get; set; }
    }
}
