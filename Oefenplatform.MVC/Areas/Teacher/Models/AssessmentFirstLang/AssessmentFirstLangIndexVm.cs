using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Teacher.Models.AssessmentFirstLang
{
    public class AssessmentFirstLangIndexVm
    {
        [Display(Name = "Testen")]
        public ICollection<Assessment> SelectedAssessments { get; set; }
    }
}
