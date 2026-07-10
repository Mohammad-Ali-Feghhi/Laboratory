using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Services;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly LabContext _db;

        public DoctorRepository()
        {
            _db = new LabContext();
        }

        public Result<Doctor> AddNewDoctor(Doctor newDoctor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newDoctor.DoctorName))
                {
                    return Result<Doctor>.Fail(ErrorCode.ValidationError, "نام دکتر الزامی است.");
                }

                if (string.IsNullOrWhiteSpace(newDoctor.MedicalLicenseNumber))
                {
                    return Result<Doctor>.Fail(ErrorCode.ValidationError, "شماره نظام پزشکی الزامی است.");
                }

                if (newDoctor.MedicalLicenseNumber.Length < 4)
                {
                    const string msgError = "شماره نظام پزشکی درست وارد نشده است.";
                    return Result<Doctor>.Fail(ErrorCode.ValidationError, msgError);
                }
                _db.Doctor.Add(newDoctor);
                _db.SaveChanges();
                return Result<Doctor>.Success(newDoctor);
            }
            catch (Exception ex)
            {
                return Result<Doctor>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Doctor> UpdateDoctor(Doctor newDoctor)
        {
            try
            {
                var oldDoctor = _db.Doctor.FirstOrDefault(x => x.DoctorId == newDoctor.DoctorId &&
                                                               x.IsDeleted == false);
                if (oldDoctor == null)
                {
                    return Result<Doctor>.Fail(ErrorCode.UserNotFound, "دکتر مورد نظر پیدا نشد.");
                }

                if (string.IsNullOrWhiteSpace(newDoctor.DoctorName))
                {
                    return Result<Doctor>.Fail(ErrorCode.ValidationError, "نام دکتر الزامی است.");
                }

                if (string.IsNullOrWhiteSpace(newDoctor.MedicalLicenseNumber))
                {
                    return Result<Doctor>.Fail(ErrorCode.ValidationError, "شماره نظام پزشکی الزامی است.");
                }

                if (newDoctor.MedicalLicenseNumber.Length < 5)
                {
                    const string msgError = "شماره نظام پزشکی درست وارد نشده است.";
                    return Result<Doctor>.Fail(ErrorCode.ValidationError, msgError);
                }

                oldDoctor.DoctorName = newDoctor.DoctorName;
                oldDoctor.MedicalLicenseNumber = newDoctor.MedicalLicenseNumber;
                oldDoctor.Description = newDoctor.Description;
                oldDoctor.IsEnabled = newDoctor.IsEnabled;
                oldDoctor.IsUpdated = newDoctor.IsUpdated;
                oldDoctor.UpdateTime = newDoctor.UpdateTime;
                _db.SaveChanges();
                return Result<Doctor>.Success(newDoctor);
            }
            catch (Exception ex)
            {
                return Result<Doctor>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Doctor> GetDoctorByDoctorId(int doctorId)
        {
            try
            {
                var doctor = _db.Doctor.FirstOrDefault(x => x.DoctorId == doctorId && x.IsDeleted == false);
                if (doctor == null)
                {
                    return Result<Doctor>.Fail(ErrorCode.UserNotFound, "پزشک مورد نظر پیدا نشد.");
                }
                return Result<Doctor>.Success(doctor);
            }
            catch (Exception ex)
            {
                return Result<Doctor>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Doctor> GetDoctorByMedicalLicenseNumber(string licenseNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(licenseNumber))
                {
                    return Result<Doctor>.Fail(ErrorCode.ValidationError, "شماره نظام پزشکی الزامی است.");
                }

                var doctor = _db.Doctor.FirstOrDefault(x => x.MedicalLicenseNumber == licenseNumber &&
                                                            x.IsDeleted == false);
                if (doctor == null)
                {
                    return Result<Doctor>.Fail(ErrorCode.UserNotFound, "دکتر مورد نظر پیدا نشد.");
                }
                return Result<Doctor>.Success(doctor);
            }
            catch (Exception ex)
            {
                return Result<Doctor>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Doctor> HasExistMedicalLicenseNumber(string licenseNumber)
        {
            try
            {
                var existLicenseNumber = _db.Doctor.Any(x => x.MedicalLicenseNumber == licenseNumber && 
                                                             x.IsDeleted == false);
                var msgExistLicenseNumber = $"شماره نظام پزشکی {licenseNumber} قبلاً ثبت شده است.";
                return existLicenseNumber ? Result<Doctor>.Fail(ErrorCode.ValidationError, msgExistLicenseNumber) :
                                            Result<Doctor>.Success(default);
            }
            catch (Exception ex)
            {
                return Result<Doctor>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public List<Doctor> GetAllDoctors()
        {
            return _db.Doctor.Where(x => x.IsDeleted == false)
                             .OrderBy(x => x.DoctorName)
                             .ToList();
        }
        public List<Doctor> GetAllDeactiveDoctors()
        {
            return _db.Doctor.Where(x => x.IsEnabled == false && x.IsDeleted == false)
                             .OrderBy(x => x.DoctorName)
                             .ToList();
        }
        public List<DoctorSearchListItem> SearchDoctor(string phrase)
        {
            var q = from d in _db.Doctor
                where d.DoctorName.StartsWith(phrase) ||
                      d.MedicalLicenseNumber.StartsWith(phrase) &&
                      d.IsDeleted == false
                select new DoctorSearchListItem
                {
                    DoctorId = d.DoctorId,
                    DoctorName = d.DoctorName,
                    MedicalLicenseNumber = d.MedicalLicenseNumber,
                    Description = d.Description,
                    UpdateTime = d.UpdateTime,
                    IsEnabled = d.IsEnabled,
                    IsUpdated = d.IsUpdated,
                    IsDeleted = d.IsDeleted
                };
            return q.OrderBy(x => x.DoctorName).ToList();
        }
        public Result<Doctor> DeleteDoctor(int doctorId)
        {
            try
            {
                var existTestAcceptionHeader = _db.TestAcceptionHeader.Any(x => x.DoctorId == doctorId &&
                                                                                x.IsDeleted == false);
                if (existTestAcceptionHeader)
                {
                    const string errorMsg = "نام این دکتر در آزمایش ثبت شده است و امکان حذف وجود ندارد!";
                    return Result<Doctor>.Fail(ErrorCode.ValidationError, errorMsg);
                }

                var doctor = _db.Doctor.FirstOrDefault(x => x.DoctorId == doctorId);
                if (doctor == null)
                {
                    return Result<Doctor>.Fail(ErrorCode.UserNotFound, "دکتر مورد نظر پیدا نشد!");
                }

                doctor.IsDeleted = true;
                _db.SaveChanges();
                return Result<Doctor>.Success(doctor);
            }
            catch (Exception ex)
            {
                return Result<Doctor>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Doctor> EnableDoctor(int doctorId)
        {
            try
            {
                var doctor = _db.Doctor.FirstOrDefault(x => x.DoctorId == doctorId && x.IsDeleted == false);
                if (doctor == null)
                {
                    return Result<Doctor>.Fail(ErrorCode.UserNotFound, "پزشک پیدا نشد!");
                }

                doctor.IsEnabled = true;
                _db.SaveChanges();
                return Result<Doctor>.Success(doctor);
            }
            catch (Exception ex)
            {
                return Result<Doctor>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<List<TestAcceptionHeader>> GetAllTestAcceptionsByDoctorId(int doctorId)
        {
            try
            {
                var exist = _db.TestAcceptionHeader.Any(x => x.DoctorId == doctorId && 
                                                             x.IsDeleted == false);
                if (exist)
                {
                    var list = _db.TestAcceptionHeader.Where(x => x.DoctorId == doctorId && 
                                                                  x.IsDeleted == false).ToList();
                    return Result<List<TestAcceptionHeader>>.Success(list);
                }

                var doctorName = _db.Doctor.FirstOrDefault(x => x.DoctorId == doctorId && x.IsDeleted == false);
                if (doctorName != null)
                {
                    var errorMsg = $"برای دکتر {doctorName.DoctorName} آزمایش ثبت نشده است.";
                    return Result<List<TestAcceptionHeader>>.Fail(ErrorCode.ValidationError, errorMsg);
                }

                const string notFoundDoctor = "دکتر مورد نظر پیدا نشد!";
                return Result<List<TestAcceptionHeader>>.Fail(ErrorCode.UserNotFound, notFoundDoctor);
            }
            catch (Exception ex)
            {
                return Result<List<TestAcceptionHeader>>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
    }
}
