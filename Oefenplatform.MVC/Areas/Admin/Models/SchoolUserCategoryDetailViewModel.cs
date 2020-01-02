using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Admin.Models
{
    public class SchoolUserCategoryDetailViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Gelieve een soort gebruiker in te geven.")]
        public string Category { get; set; }
    }
}
