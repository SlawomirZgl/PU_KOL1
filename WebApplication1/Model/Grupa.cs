﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Grupa
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }

}
