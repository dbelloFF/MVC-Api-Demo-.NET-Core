﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPIDemo.DTOs
{
    public class CommandCreateDto
    {
        //[Key] -- Id is autogenerated no need to pass it through the DTO
        //public int Id { get; set; }

        //[Required]
        //[MaxLength(250)]
        public string HowTo { get; set; }

        //[Required]
        public string Line { get; set; }

        //[Required]
        public string Platform { get; set; }
    }
}
