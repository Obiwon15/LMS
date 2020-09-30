using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data.Interfaces
{
    public interface IRepository
    {

        PatientForm GetPatient(int Id);
        PatientTest GetPatientTest(int TestId);
        List<PatientForm> GetAllPatients();
        //Physician
        List<Physician> GetAllPhysicians();
        Physician GetPhysician(int Id);
        void AddPhysician(Physician physician);
        void RemovePhysician(Physician physician);
        void UpdatePhysician(Physician physician);
        //List<PatientForm> GetAllPatients(string physician);
        void AddPatient(PatientForm patient);
        void RemovePatient(PatientForm patient);
        void UpdatePatient(PatientForm patient);

        Task<bool> SaveChangesAsync();
    }
}
