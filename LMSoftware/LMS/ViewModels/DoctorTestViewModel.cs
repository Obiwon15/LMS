using LMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.ViewModels
{
    public class DoctorTestViewModel
    {
        public int PatientId { get; set; }
        public int PhysicianId { get; set; }
        public int DepartmentId { get; set; }
        public List<SelectListItem> deptL { get; set; }
        public int TestId { get; set; }
        public string PhysicianName { get; set; }
        public string TestName { get; set; }
        //public string DepartmentName { get; set; }


    }
}
