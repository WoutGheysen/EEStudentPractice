using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.Lib.Models
{
    public class EntityBase<Tkey>
    {
        public Tkey Id { get; set; }
        //public DateTime Created { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
