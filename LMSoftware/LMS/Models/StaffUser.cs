using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class StaffUser: IdentityUser
    {
        public int StaffId { get; set; }
        public string Fullname { get; set; }
        //public string Role { get; set; }
        //public string Mobile { get; set; }
    }
}
