using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class AppDbContext : IdentityDbContext<StaffUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<PatientTest> Tests { get; set; }

        public DbSet<PatientForm> Patients { get; set; }
        public DbSet<TestDepartment> Departments { get; set; }
        public DbSet<TestRegister> Appointments { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<TestResult> Results { get; set; }



    }
}
