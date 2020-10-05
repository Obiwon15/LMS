using LMS.Data.Interfaces;
using LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _ctx;
        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPatient(PatientForm patient)
        {
            _ctx.Patients.Add(patient);
        }

        public void AddPhysician(Physician physician)
        {
            _ctx.Physicians.Add(physician);
        }

        public List<PatientForm> GetAllPatients()
        {
            return _ctx.Patients.Include(p => p.Physician).Include(s => s.Test).ToList();
        }

        public List<Physician> GetAllPhysicians()
        {
            return _ctx.Physicians.ToList();
        }
        //public List<PatientForm> GetAllPatients(string physician)
        //{
        //    Func<PatientForm, bool> InCategory = (PatientForm) => { return PatientForm.Physician.ToLower().Equals(PatientTest.ToLower()); };

        //    return _ctx.Patients.Where(PatientForm => InCategory(physician)).ToList();
        //}



        public PatientForm GetPatient(int Id)
        {
            return _ctx.Patients.Include(p => p.Physician).Include(s => s.Test).FirstOrDefault(s => s.Id == Id);
        }
        public PatientTest GetPatientTest(int TestId)
        {
            return _ctx.Tests.Include(z => z.Department).FirstOrDefault(s => s.TestId == TestId);
        }

        public Physician GetPhysician(int Id)
        {
            return _ctx.Physicians.FirstOrDefault(p => p.Id == Id);
        }

        public void RemovePatient(PatientForm patient)
        {
           _ctx.Patients.Remove(patient);
            //_ctx.Tests.Remove(GetPatientTest(Id));
        }

        public void RemovePhysician(Physician physician)
        {
            _ctx.Physicians.Remove(physician);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void UpdatePatient(PatientForm patient)
        {
            _ctx.Patients.Update(patient);
        }

        public void UpdatePhysician(Physician physician)
        {
            _ctx.Physicians.Update(physician);
        }
    }
}
