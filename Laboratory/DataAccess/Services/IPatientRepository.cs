using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess.Services
{
    public interface IPatientRepository
    {
        Result<Patient> AddNewPatient(Patient patient);
        Result<Patient> UpdatePatient(Patient newPatient);
        Result<Patient> GetPatientByPatientId(int patientId);
        Result<Patient> HasExistNationalCode(string nationalCode);
        Result<Patient> DeletePatient(int patientId);
        Result<Patient> PatientCheckingValidation(PatientCheckingValidationItem item);
        List<Patient> GetAllPatients();
        List<PatientTestListItem> GetPatientTestListByPatientId(int patientId);
        List<PatientSearchListItem> SearchPatient(string phrase);
    }
}
