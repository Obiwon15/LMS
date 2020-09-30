using LMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.ViewModels
{
    public class AppDeptViewModel
    {
        public int  TestId{ get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public ICollection<PatientForm> patient { get; set; }
        public ICollection<PatientTest> test { get; set; }
        public ICollection<TestRegister> app { get; set; }

        public List<SelectListItem> patL { get; set; }
        public string ClinicalDiagnosis { get; set; }
        public int ClinicNo { get; set; }
        public DateTime DateOfRequest { get; set; }
        public DateTime Date { get; set; }
        public string TestName { get; set; }
        public List<SelectListItem> TestL { get; set; }

        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public bool IsCompleted { get; set; }
        public int ResultId { get; set; }
    }
}
