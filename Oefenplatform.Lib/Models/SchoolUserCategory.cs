using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Oefenplatform.Lib.Models
{
    public class SchoolUserCategory : EntityBase<int>
    {
        [Required(ErrorMessage = "Gelieve een soort gebruiker in te geven.")]
        public string Category { get; set; }

    }
}
