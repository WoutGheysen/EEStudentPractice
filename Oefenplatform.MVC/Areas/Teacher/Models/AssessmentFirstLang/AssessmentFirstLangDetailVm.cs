using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Teacher.Models.AssessmentFirstLang
{
    public class AssessmentFirstLangDetailVm
    {
        public int Id { get; set; }
        public string AssessmentTitle { get; set; }
        public ICollection<AssessmentDetail> RelatedAssessments { get; set; }
    }
}
