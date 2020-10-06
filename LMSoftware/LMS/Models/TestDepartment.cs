using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class TestDepartment
    {
        [Key]
        public int DeptId { get; set; }
        public string Department { get; set; } = "";
        public virtual PatientTest Tests { get; set; } = new PatientTest { };
        //public int TestId { get; set; }
        //public ICollection<PatientTest> Tests { get; set; }

        //public string ClinicalChemistry { get; set; } = "";
        //public string Microbiology { get; set; } = "";
        //public string Haematology { get; set; } = "";
        //public string HormonalAssay { get; set; } = "";
        //public string DrugsOfAbuseTesting { get; set; } = "";
        //public string Miscellaneous { get; set; } = "";
        //public string OtherTests { get; set; } = "";

    }
}
