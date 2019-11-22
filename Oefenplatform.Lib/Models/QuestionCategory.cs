
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Oefenplatform.Lib.Models
{
    public class QuestionCategory: EntityBase<int>
    {
        [Required(ErrorMessage = "Gelieve een vraagsoort in te geven.")]
        public string CategoryQuestion { get; set; }
        //public ICollection<Question> Questions { get; set; }

    }
}
