using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Services;
using DomainModel.BussinessModel;
using DomainModel.Models;
using DomainModel.Results;

namespace DataAccess
{
    public class PatientRepository : IPatientRepository
    {
        private readonly LabContext _db;

        public PatientRepository()
        {
            this._db = new LabContext();
        }

        public Result<Patient> AddNewPatient(Patient patient)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(patient.PatientName))
                {
                    return Result<Patient>.Fail(ErrorCode.ValidationError, "نام بیمار الزامی است!");
                }

                if (string.IsNullOrWhiteSpace(patient.NationalCode))
                {
                    return Result<Patient>.Fail(ErrorCode.ValidationError, "کد ملی الزامی است!");
                }

                if (patient.BirthDate == null)
                {
                    return Result<Patient>.Fail(ErrorCode.ValidationError, "تاریخ تولد الزامیست!");
                }

                if (string.IsNullOrWhiteSpace(patient.Mobile))
                {
                    return Result<Patient>.Fail(ErrorCode.ValidationError, "شماره تلفن همراه الزامی است!");
                }

                _db.Patient.Add(patient);
                _db.SaveChanges();
                return Result<Patient>.Success(patient);
            }
            catch (Exception ex)
            {
                return Result<Patient>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Patient> UpdatePatient(Patient newPatient)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newPatient.PatientName))
                {
                    return Result<Patient>.Fail(ErrorCode.ValidationError, "نام بیمار الزامیست!");
                }

                if (string.IsNullOrWhiteSpace(newPatient.NationalCode))
                {
                    return Result<Patient>.Fail(ErrorCode.ValidationError, "کد ملی الزامیست!");
                }

                if (string.IsNullOrWhiteSpace(newPatient.Mobile))
                {
                    return Result<Patient>.Fail(ErrorCode.ValidationError, "شماره تلفن همراه الزامیست!");
                }

                if (newPatient.BirthDate == null)
                {
                    return Result<Patient>.Fail(ErrorCode.ValidationError, "تاریخ تولد الزامیست!");
                }

                if (newPatient.NationalCode.Length < 10)
                {
                    return Result<Patient>.Fail(ErrorCode.ValidationError, "کد ملی را درست وارد کنید!");
                }

                if (newPatient.Mobile.Length < 11)
                {
                    return Result<Patient>.Fail(ErrorCode.ValidationError, "شماره تلفن همراه را درست وارد کنید!");
                }

                var oldPatient = _db.Patient.FirstOrDefault(x => x.PatientId == newPatient.PatientId &&
                                                                 x.IsDeleted == false);
                if (oldPatient == null)
                {
                    return Result<Patient>.Fail(ErrorCode.UserNotFound, "بیمار پیدا نشد.");
                }

                oldPatient.PatientName = newPatient.PatientName;
                oldPatient.NationalCode = newPatient.NationalCode;
                oldPatient.BirthDate = newPatient.BirthDate;
                oldPatient.Mobile = newPatient.Mobile;
                oldPatient.Description = newPatient.Description;
                oldPatient.UpdateTime = newPatient.UpdateTime;
                oldPatient.IsUpdated = newPatient.IsUpdated;
                _db.SaveChanges();
                return Result<Patient>.Success(newPatient);
            }
            catch (Exception ex)
            {
                return Result<Patient>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Patient> GetPatientByPatientId(int patientId)
        {
            try
            {
                var patient = _db.Patient.FirstOrDefault(x => x.PatientId == patientId && x.IsDeleted == false);
                return patient == null ? Result<Patient>.Fail(ErrorCode.UserNotFound, "بیمار پیدا نشد!") :
                                         Result<Patient>.Success(patient);
            }
            catch (Exception ex)
            {
                return Result<Patient>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Patient> HasExistNationalCode(string nationalCode)
        {
            try
            {
                var existNationalCode = _db.Patient.Any(x => x.NationalCode == nationalCode && 
                                                             x.IsDeleted == false);
                if (existNationalCode)
                {
                    return Result<Patient>.Success(default);
                }

                return Result<Patient>.Fail(ErrorCode.UserNotFound, "کد ملی مورد نظر پیدا نشد!");
            }
            catch (Exception ex)
            {
                return Result<Patient>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Patient> DeletePatient(int patientId)
        {
            try
            {
                var existTestAcception = _db.TestAcceptionHeader.Any(x => x.PatientId == patientId && 
                                                                          x.IsDeleted == false);
                if (existTestAcception)
                {
                    const string msg = "بیمار دارای آزمایش است و امکان حذف وجود ندارد!";
                    return Result<Patient>.Fail(ErrorCode.ValidationError, msg);
                }

                var patient = _db.Patient.FirstOrDefault(x => x.PatientId == patientId);
                if (patient == null)
                {
                    return Result<Patient>.Fail(ErrorCode.UserNotFound, "بیمار پیدا نشد.");
                }

                patient.IsDeleted = true;
                _db.SaveChanges();
                return Result<Patient>.Success(patient);
            }
            catch (Exception ex)
            {
                return Result<Patient>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public Result<Patient> PatientCheckingValidation(PatientCheckingValidationItem item)
        {
            try
            {
                var patient = _db.Patient.FirstOrDefault(x => x.NationalCode == item.NationalCode || 
                                                              x.Mobile == item.Mobile &&
                                                              x.IsDeleted == false);
                if (patient == null)
                {
                    return Result<Patient>.Success(default);
                }

                const string errorMsg = @"کد ملی و یا تلفن همراه قبلاً ثبت شده است!";
                return Result<Patient>.Fail(ErrorCode.ValidationError, errorMsg);
            }
            catch (Exception ex)
            {
                return Result<Patient>.Fail(ErrorCode.DatabaseError, ex.Message);
            }
        }
        public List<Patient> GetAllPatients()
        {
            return _db.Patient.Where(x => x.IsDeleted == false)
                              .OrderBy(x => x.PatientName)
                              .ToList();
        }
        public List<PatientTestListItem> GetPatientTestListByPatientId(int patientId)
        {
            var query = from item in _db.TestAcceptionHeader
                where item.PatientId == patientId &&
                      item.IsDeleted == false
                select new PatientTestListItem
                {
                    TestAcceptionHeaderId = item.TestAcceptionHeaderId,
                    DoctorId = item.DoctorId,
                    DoctorName = item.Doctor.DoctorName,
                    RegistrationEmployeeId = item.RegistrationEmployeeId,
                    RegistrationEmployeeName = item.Employee.EmployeeName,
                    AcceptionDate = item.AcceptionDate,
                };
            return query.OrderByDescending(x => x.TestAcceptionHeaderId).ToList();
        }
        public List<PatientSearchListItem> SearchPatient(string phrase)
        {
            var q = from p in _db.Patient
                where
                    p.PatientName.StartsWith(phrase) ||
                    p.NationalCode.StartsWith(phrase) ||
                    p.Mobile.StartsWith(phrase) &&
                    p.IsDeleted == false
                select new PatientSearchListItem
                {
                    PatientId = p.PatientId,
                    PatientName = p.PatientName,
                    NationalCode = p.NationalCode,
                    Mobile = p.Mobile,
                    BirthDate = p.BirthDate,
                    Description = p.Description,
                    UpdateTime = p.UpdateTime,
                    IsUpdated = p.IsUpdated,
                    IsDeleted = p.IsDeleted,
                    PatientFullInfo = p.PatientName + " | " + p.Mobile + " | " + p.NationalCode
                };
            return q.OrderBy(x => x.PatientName).ToList();
        }
    }
}
