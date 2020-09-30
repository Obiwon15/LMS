using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Physician { get; set; }
        public string ClinicalDiagnosis { get; set; }
        public DateTime DateOfRequest { get; set; }
        public int ClinicNo { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public int TestId { get; set; }
        public int PhysicianId { get; set; }
        public int DepartmentId { get; set; }
        public List<SelectListItem> docL { get; set; }
        public List<SelectListItem> tesL { get; set; }

        //public string ClinicalChemistry { get; set; }
        //public string Microbiology { get; set; }
        //public string Haematology { get; set; }
        //public string HormonalAssay { get; set; }
        //public string DrugsOfAbuseTesting { get; set; }
        //public string Miscellaneous { get; set; }
        //public string OtherTests { get; set; }
        //public IEnumerable<PatientForm> Patients { get; set; }
    }
}
