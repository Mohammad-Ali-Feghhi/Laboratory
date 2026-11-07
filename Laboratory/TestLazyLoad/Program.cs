using System;
using System.Data.Entity;
using DataAccess;
using DomainModel.Models;
using DomainModel.Results;

namespace TestLazyLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Lazy Load Test with AsNoTracking ===");
            Console.WriteLine();

            TestDoctorRepository();
            TestPatientRepository();
            TestEmployeeRepository();

            Console.WriteLine();
            Console.WriteLine("=== Test Complete ===");
            Console.ReadKey();
        }

        static void TestDoctorRepository()
        {
            Console.WriteLine("--- Testing DoctorRepository ---");
            var repo = new DoctorRepository();

            // Test 1: GetAllDoctors with AsNoTracking
            Console.WriteLine("Test 1: GetAllDoctors() - Access Navigation Property");
            var doctors = repo.GetAllDoctors();
            if (doctors.Count > 0)
            {
                var firstDoctor = doctors[0];
                Console.WriteLine($"  Doctor: {firstDoctor.DoctorName} (ID: {firstDoctor.DoctorId})");

                // Try to access Navigation Property (should be null or throw with AsNoTracking)
                try
                {
                    var count = firstDoctor.TestAcceptionHeader?.Count ?? 0;
                    Console.WriteLine($"  TestAcceptionHeader.Count = {count} (Expected: 0 or Null with AsNoTracking)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  EXCEPTION accessing Navigation: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("  No doctors found in database");
            }

            // Test 2: GetDoctorByDoctorId with AsNoTracking
            Console.WriteLine();
            Console.WriteLine("Test 2: GetDoctorByDoctorId(1) - Access Navigation Property");
            var doctorResult = repo.GetDoctorByDoctorId(1);
            if (doctorResult.IsSuccess && doctorResult.Data != null)
            {
                var doctor = doctorResult.Data;
                Console.WriteLine($"  Doctor: {doctor.DoctorName} (ID: {doctor.DoctorId})");

                try
                {
                    var count = doctor.TestAcceptionHeader?.Count ?? 0;
                    Console.WriteLine($"  TestAcceptionHeader.Count = {count} (Expected: 0 or Null with AsNoTracking)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  EXCEPTION accessing Navigation: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"  Doctor not found: {doctorResult.Message}");
            }
            Console.WriteLine();
        }

        static void TestPatientRepository()
        {
            Console.WriteLine("--- Testing PatientRepository ---");
            var repo = new PatientRepository();

            // Test 1: GetAllPatients with AsNoTracking
            Console.WriteLine("Test 1: GetAllPatients() - Access Navigation Property");
            var patients = repo.GetAllPatients();
            if (patients.Count > 0)
            {
                var firstPatient = patients[0];
                Console.WriteLine($"  Patient: {firstPatient.PatientName} (ID: {firstPatient.PatientId})");

                try
                {
                    var count = firstPatient.TestAcceptionHeader?.Count ?? 0;
                    Console.WriteLine($"  TestAcceptionHeader.Count = {count} (Expected: 0 or Null with AsNoTracking)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  EXCEPTION accessing Navigation: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("  No patients found in database");
            }

            // Test 2: GetPatientByPatientId with AsNoTracking
            Console.WriteLine();
            Console.WriteLine("Test 2: GetPatientByPatientId(1) - Access Navigation Property");
            var result = repo.GetPatientByPatientId(1);
            if (result.IsSuccess && result.Data != null)
            {
                var patient = result.Data;
                Console.WriteLine($"  Patient: {patient.PatientName} (ID: {patient.PatientId})");

                try
                {
                    var count = patient.TestAcceptionHeader?.Count ?? 0;
                    Console.WriteLine($"  TestAcceptionHeader.Count = {count} (Expected: 0 or Null with AsNoTracking)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  EXCEPTION accessing Navigation: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"  Patient not found: {result.Message}");
            }
            Console.WriteLine();
        }

        static void TestEmployeeRepository()
        {
            Console.WriteLine("--- Testing EmployeeRepository ---");
            var repo = new EmployeeRepository();

            // Test 1: GetAllEmployees with AsNoTracking
            Console.WriteLine("Test 1: GetAllEmployees() - Access Navigation Property");
            var employees = repo.GetAllEmployees();
            if (employees.Count > 0)
            {
                var firstEmp = employees[0];
                Console.WriteLine($"  Employee: {firstEmp.EmployeeName} (ID: {firstEmp.EmployeeId})");

                try
                {
                    var count = firstEmp.LoginHistory?.Count ?? 0;
                    Console.WriteLine($"  LoginHistory.Count = {count} (Expected: 0 or Null with AsNoTracking)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  EXCEPTION accessing Navigation: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("  No employees found in database");
            }

            // Test 2: GetEmployeeByEmployeeId with AsNoTracking
            Console.WriteLine();
            Console.WriteLine("Test 2: GetEmployeeByEmployeeId(1) - Access Navigation Property");
            var emp = repo.GetEmployeeByEmployeeId(1);
            if (emp != null)
            {
                Console.WriteLine($"  Employee: {emp.EmployeeName} (ID: {emp.EmployeeId})");

                try
                {
                    var count = emp.LoginHistory?.Count ?? 0;
                    Console.WriteLine($"  LoginHistory.Count = {count} (Expected: 0 or Null with AsNoTracking)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  EXCEPTION accessing Navigation: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("  Employee not found");
            }
            Console.WriteLine();
        }
    }
}