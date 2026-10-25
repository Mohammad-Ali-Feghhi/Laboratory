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
    public interface IDoctorRepository : IDisposable
    {
        Result<Doctor> AddNewDoctor(Doctor newDoctor);
        Result<Doctor> UpdateDoctor(Doctor newDoctor);
        Result<Doctor> GetDoctorByDoctorId(int doctorId);
        Result<Doctor> GetDoctorByMedicalLicenseNumber(string licenseNumber);
        Result<Doctor> HasExistMedicalLicenseNumber(string licenseNumber);
        List<Doctor> GetAllDoctors();
        List<Doctor> GetAllDeactiveDoctors();
        List<DoctorSearchListItem> SearchDoctor(string phrase);
        Result<Doctor> DeleteDoctor(int doctorId);
        Result<Doctor> EnableDoctor(int doctorId);
        Result<List<TestAcceptionHeader>> GetAllTestAcceptionsByDoctorId(int doctorId);
    }
}
