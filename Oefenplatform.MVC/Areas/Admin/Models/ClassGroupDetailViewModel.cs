using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Admin.Models
{
    public class ClassGroupDetailViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Gelieve een klasnaam in te geven.")]
        public string ClassGroupName { get; set; }
        [Required(ErrorMessage = "Gelieve de graad in te geven.")]
        public YearGrade YearGrade { get; set; }
        [BindProperty]
        public int SelectedYearGradeId { get; set; }
        public SelectList YearGradeOptions { get; set; }
        [Required(ErrorMessage = "Gelieve de klasleden in te geven.")]
        public ICollection<SchoolUser> SchoolUsers { get; set; }
    }
}
