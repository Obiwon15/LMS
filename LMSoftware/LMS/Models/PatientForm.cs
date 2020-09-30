using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class PatientForm
    {
        [Key]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string ClinicalDiagnosis { get; set; }
        public DateTime DateOfRequest { get; set; }
        public int ClinicNo { get; set; } 
        public int Age { get; set; }
        public string Department { get; set; }
        public int DepartmentId { get; set; }
        public int PhysicianId { get; set; }
        public int testId { get; set; }
        //public virtual TestDepartment Departments { get; set; }
        //////public int TestId { get; set; } = 0;
        //////public int PhysicianId { get; set; } = 0;
        public virtual PatientTest Test { get; set; }
        public virtual Physician Physician { get; set; }


    }
}
