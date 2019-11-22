using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Oefenplatform.Lib.Models
{
    public class WrongAnswer : EntityBase<int>
    {
        public string SchoolUserResponse { get; set; }
        [NotMapped]
        public Question Question { get; set; }
    }
}
