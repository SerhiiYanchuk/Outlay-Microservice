﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.Models
{
    public class User
    {

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
 
        public string Surname { get; set; }
     
        public int Age { get; set; }
        

    }
}
