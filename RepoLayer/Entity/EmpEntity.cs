using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepoLayer.Entity
{
    public class EmpEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmpId { get; set; }
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
