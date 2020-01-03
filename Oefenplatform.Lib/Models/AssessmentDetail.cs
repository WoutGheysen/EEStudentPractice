using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oefenplatform.Lib.Models
{
    public class AssessmentDetail : EntityBase<int>
    {
        public string AssessmentTitle { get; set; }
        public ICollection<WrongAnswer> WrongAnswers { get; set; }
        public Assessment Assessment { get; set; }
        public ICollection<Question> Questions { get; set; }
        public int AssessmentId { get; set; }
    }
}
