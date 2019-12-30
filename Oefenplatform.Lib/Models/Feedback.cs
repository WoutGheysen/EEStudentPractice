using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Oefenplatform.Lib.Models
{
    public class Feedback : EntityBase<int>
    {
        //[Required(ErrorMessage = "Gelieve de vraag voor de feedback in te geven.")]
        [JsonIgnore]
        public Question Question { get; set; }
        public int? QuestionId { get; set; }
        //[Required(ErrorMessage = "Gelieve de feedbacknummer in te geven.")]
        public int Reference { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
    }
}
