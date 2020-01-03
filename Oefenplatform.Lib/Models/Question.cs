using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.Lib.Models
{
    public class Question : EntityBase<int>
    {
        [Required(ErrorMessage = "Gelieve een vraag in te geven.")]
        public string QuestionTitle { get; set; }
        public string Description { get; set; }
        //public CourseCategory CourseCategory { get; set; }
        public int? StartNumber { get; set; }
        [Required(ErrorMessage = "Gelieve de feedback voor de vraag in te geven.")]
        public ICollection<Feedback> Feedback { get; set; }
        [Required(ErrorMessage = "Gelieve het antwoord in te geven.")]
        public Answer Answer { get; set; }
        //public Assessment Assessment { get; set; }
        public string FileName { get; set; }
        public int Attempts { get; set; }
        [Required(ErrorMessage = "Gelieve de vraagsoort in te geven.")]
        public QuestionCategory QuestionCategory { get; set; }
        //public ICollection<WrongAnswer> WrongAnswers { get; set; }
        //collection feedback
        public int AnswerId { get; set; }
        public int QuestionCategoryId { get; set; }
    }
}
