using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class PatientTest
    {
        [Key]
        public int TestId { get; set; }
        public string TestName { get; set; } = "";
        public int DepartmentId { get; set; }
        public virtual TestDepartment Department { get; set; } = new TestDepartment { };
        public virtual PatientForm patients { get; set; } = new PatientForm { };
    }
}
