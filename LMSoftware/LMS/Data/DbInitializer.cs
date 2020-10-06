using LMS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{

    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {

            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                //AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

                //UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();


                // Add Customers
                //var justin = new PatientForm
                //{
                //var user = new IdentityUser("tenece");
                // userManager.CreateAsync(user, "%ten");

                var mike = new Physician
                {
                    Id = 2,
                    PhysicianName = "Dave bane"

                };

                context.Physicians.Add(mike);

                var pat = new PatientForm
                {
                    Id = 1,
                    Fullname = "Justin Noon",
                    Age = 27,
                    ClinicalDiagnosis = "RVS",
                    ClinicNo = 3,

                    DepartmentId = 3,
                    //Test = new PatientTest
                    //{
                    //    t
                    //}
                    //PhysicianId = 2,
                    //Test = 5,


                    //Department = "Infection and Disease"
                };
                context.Patients.Add(pat);

                var arv = new PatientTest
                {
                    TestId = 5,
                    TestName = "HIV",
                    DepartmentId = 3
                };
                context.Tests.Add(arv);

                var vir = new TestDepartment
                {
                    DeptId = 3,
                    Department = "Virus"
                };
                context.Departments.Add(vir);
                //};

                var ruth = new TestRegister
                {
                    Id = 1,
                    Date = DateTime.Now,
                    PatientId = 1,
                    TId = 5,
                    ResultId = 8
                };
                context.Appointments.Add(ruth);
                var res = new TestResult
                {
                    Id = 8,
                    IsCompleted = true
                };
                context.Results.Add(res);
                context.SaveChanges();
            }
        }
    }
}
