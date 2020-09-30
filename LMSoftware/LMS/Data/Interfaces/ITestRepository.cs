using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<PatientTest> GetTestPatients(int TestId);
        List<TestRegister> GetAppointments();
        TestRegister GetAppointment(int Id);
        void AddAppointment(TestRegister reg);
        void RemoveAppointment(TestRegister reg);
        void UpdateAppointment(TestRegister reg);

        //Department
        List<TestDepartment> GetAllDepartments();
        TestDepartment GetDepartment(int Id);
        IEnumerable<TestDepartment> GetTestDept(int DeptId);
        void AddDepartment(TestDepartment dept);
        void RemoveDepartment(TestDepartment dept);
        void UpdateDepartment(TestDepartment dept);
        //Tests
        PatientTest GetTest(int Id);
        //List<PatientTest> GetTests();
        List<PatientTest> GetAllTests();
        //List<PatientForm> GetAllPatients(string physician);
        void AddTest(PatientTest test);
        void RemoveTest(PatientTest test);
        void UpdateTest(PatientTest test);
        Task<bool> SaveChangesAsync();
    }
}
