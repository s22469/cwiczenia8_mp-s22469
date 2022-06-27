using Recepty.Dtos;
using Recepty.Models;
using System;
using System.Collections.Generic;

namespace Recepty.Services
{
    public class DtoConverter
    {
        public static DoctorDto MapToDoctorDto(Doctor doctor)
        {
            return new DoctorDto
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
        }
        public static PrescriptionDto MapToPrescriptionDto(Prescription prescription)
        {
            Console.WriteLine(prescription.Prescriptions_Medicament);
            return new PrescriptionDto
            {
                Patient = DtoConverter.MapToPatientDto(prescription.Patient),
                Doctor = DtoConverter.MapToDoctorDto(prescription.Doctor),
                
            };
        }
        public static PatientDto MapToPatientDto(Patient patient)
        {
            return new PatientDto
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate
            };
        }
        public static MedicamentDto MapToMedicamentDto(Medicament medicament)
        {
            return new MedicamentDto
            {
                Name = medicament.Name,
                Description = medicament.Description,
                Type = medicament.Type
            };
        }
    }
}
