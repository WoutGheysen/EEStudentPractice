using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.Lib.Models
{
    public class Assessment:EntityBase<int>
    {
        [Required(ErrorMessage = "Gelieve een titel in te voeren.")]
        public string AssessmentTitle { get; set; }
        [JsonIgnore]
        public ICollection<AssessmentDetail> AssessmentDetails { get; set; }
        public SchoolUser SchoolUser { get; set; }
        [Required(ErrorMessage = "Gelieve de test soort in te geven.")]
        public CourseCategory CourseCategory { get; set; }
        [Required(ErrorMessage = "Gelieve de graad van de test in te geven.")]
        public YearGrade YearGrade { get; set; }
    }
}
