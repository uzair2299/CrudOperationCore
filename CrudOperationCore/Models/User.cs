﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string FatherName { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }
        public string HomeAddress { get; set; }

        public string ResidentailAddress { get; set; }

        public string ProfileIamge { get; set; }
        [Required]
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        [Required]
        public int? ProvinceId { get; set; }
        public virtual Province Province { get; set; }
    }
}
