using System;
using System.Collections.Generic;
using System.Text;

namespace Oefenplatform.Lib.Models
{
    public class AssessmentDetail : EntityBase<int>
    {
        public ICollection<WrongAnswer> WrongAnswers { get; set; }
        public Assessment Assessment { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
