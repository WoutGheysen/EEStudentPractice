using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.Lib.Models
{
    public class ClassGroup : EntityBase<int>
    {
        [Required(ErrorMessage = "Gelieve een klasnaam in te geven.")]
        public string ClassGroupName { get; set; }
        //[Required(ErrorMessage = "Gelieve de graad in te geven.")]
        public YearGrade YearGrade { get; set; }
        //[Required(ErrorMessage = "Gelieve de klasleden in te geven.")]
        public int YearGradeId { get; set; }

        [JsonIgnore]
        public ICollection<SchoolUser> SchoolUsers { get; set; }
    }
}
