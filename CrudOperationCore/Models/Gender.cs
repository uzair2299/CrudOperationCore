using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Models
{
    public class Gender
    {
        public int GenderId { get; set; }
        [StringLength(15)]
        public string GenderName { get; set; }
    }
}
