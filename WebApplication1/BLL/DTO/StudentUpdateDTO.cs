﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{ 
    public class StudentUpdateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GroupID { get; set; }
    }
}
