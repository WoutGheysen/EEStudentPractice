using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Teacher.Models.AssessmentFirstLang
{
    public class AssessmentFirstLangIndexVm
    {
        public ICollection<Assessment> SelectedAssessments { get; set; }
    }
}
