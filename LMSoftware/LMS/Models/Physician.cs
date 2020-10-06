using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Physician
    {
        [Key]
        public int Id { get; set; }
        public string PhysicianName { get; set; } = "";
        public PatientForm Patients { get; set; } = new PatientForm { };

    }
}
