﻿using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Admin.Models
{
    public class UserDetailViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Gelieve een voornaam in te geven.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Gelieve een achternaam in te geven.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gelieve een klas in te geven.")]
        public ClassGroup ClassGroup { get; set; }
        public string AvatarURL { get; set; }
        [Required(ErrorMessage = "Gelieve de soort gebruiker mee te geven.")]
        public SchoolUserCategory SchoolUserCategory { get; set; }
        public string IdentityReference { get; set; }
    }
}
