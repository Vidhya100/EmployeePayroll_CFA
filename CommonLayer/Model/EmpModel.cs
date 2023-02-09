﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class EmpModel
    {
        public string EmpName { get; set; }
        public string ProfileImg { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public float Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }
    }
}
