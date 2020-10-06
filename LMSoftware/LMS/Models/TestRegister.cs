using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class TestRegister
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int PatientId { get; set; }
        //public string Fullname { get; set; }
        //public string ClinicalDiagnosis { get; set; }
        //public DateTime DateOfRequest { get; set; }
        //public int ClinicNo { get; set; }
        //public int Age { get; set; }
        //public string Department { get; set; }
        public virtual PatientForm Patient { get; set; } 
        //public virtual Physician physician { get; set; }
        public int TId { get; set; }
        public virtual PatientTest Test { get; set; } = new PatientTest { };
        public int ResultId { get; set; }
        public virtual TestResult Result { get; set; } = new TestResult { };
    }
}
