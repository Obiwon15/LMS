using LMS.Data.Interfaces;
using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _appDbContext;

        public TestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddAppointment(TestRegister reg)
        {
            _appDbContext.Appointments.Add(reg);
        }

        public void AddDepartment(TestDepartment dept)
        {
            _appDbContext.Departments.Add(dept);
        }

        public void AddTest(PatientTest patient)
        {
            _appDbContext.Tests.Add(patient);
        }

        public List<PatientTest> GetAllTests()
        {
            return _appDbContext.Tests.Include(p => p.Department).ToList();
        }

        public TestRegister GetAppointment(int Id)
        {
            return _appDbContext.Appointments
                .Include(p => p.Patient).ThenInclude(b => b.Physician)
                .Include(x => x.Result)
                .Include(z =>z.Test).ThenInclude(tb => tb.Department).FirstOrDefault(a => a.Id == Id);
        }

        public List<TestRegister> GetAppointments()
        {
            return _appDbContext.Appointments.Include(s => s.Patient).ThenInclude(b => b.Physician)
                .Include(x => x.Result).Include(z => z.Test).ThenInclude(tb => tb.Department)
                .ToList();
        }

        public TestDepartment GetDepartment(int Id)
        {
            return _appDbContext.Departments.FirstOrDefault(x => x.DeptId == Id);
        }

        public IEnumerable<TestDepartment> GetTestDept(int DeptId)
        {
            return _appDbContext.Departments.Include(t => t.Tests).Where(x => x.DeptId == DeptId).ToList();
        }

        public IEnumerable<PatientTest> GetTestPatients(int TestId)
        {
            return _appDbContext.Tests.Include(p => p.patients).Where(t => t.TestId == TestId).ToList();
        }

        //public async Task<IEnumerable<PatientForm>> GetPatientTests(int TestId, int Id)
        //{
        //   var result = await _appDbContext.Patients.Where(i => _appDbContext.Patients.Where(t => t.TestId == TestId)
        //        .Any(p => p.Id == Id)).ToListAsync();

        //    return result;
        //}

        //public PatientForm GetPatientTests(int TestId)
        //{
        //    return _appDbContext.Patients.FirstOrDefault( t => t.TestId == TestId);
        //}
        public PatientTest GetTest(int Id)
        {
            return _appDbContext.Tests.Include(p => p.Department).FirstOrDefault(p => p.TestId == Id);
        }


        public List<PatientTest> GetTests()
        {
            return _appDbContext.Tests.Include(p => p.Department).ToList();
        }

        public void RemoveAppointment(TestRegister reg)
        {
            _appDbContext.Appointments.Remove(reg);
        }

        public void RemoveDepartment(TestDepartment dept)
        {
            _appDbContext.Departments.Remove(dept);
        }

        public void RemoveTest(PatientTest test)
        {
            
            _appDbContext.Tests.Remove(test);
        }

    

        public async Task<bool> SaveChangesAsync()
        {
            if (await _appDbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void UpdateAppointment(TestRegister reg)
        {
           _appDbContext.Appointments.Update(reg);
        }

        public void UpdateDepartment(TestDepartment dept)
        {
            _appDbContext.Departments.Update(dept);
        }

        public void UpdateTest(PatientTest test)
        {
            _appDbContext.Tests.Update(test);
        }

        public List<TestDepartment> GetAllDepartments()
        {
            return _appDbContext.Departments.Include(x => x.Tests).ToList();
        }
    }
}
