
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.Lib.Models
{
    public class Answer : EntityBase<int>
    {
        public int? MathAnswer { get; set; }
        public string LangAnswer { get; set; }
    }
}
