using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.Lib.Models
{
    public class YearGrade : EntityBase<int>
    {
        [Required(ErrorMessage = "Gelieve de graad in te geven.")]
        public int Grade { get; set; }
        public ICollection<ClassGroup> ClassGroups { get; set; }
        public ICollection<Assessment> Assessments { get; set; }
    }
}
