using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recepty.Dtos;
using Recepty.Models;
using Recepty.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recepty.Controllers
{
    [ApiController]
    [Route("api/przychodnia")]
    public class ReceptyController : ControllerBase
    {
        private readonly ExampleDbContext _context;

        public ReceptyController(ExampleDbContext context)
        {
            _context = context;
        }
        [HttpGet("/doctor/id")]

        public async Task<IActionResult> getDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return BadRequest("Doctor not found");
            var doctorDto = DtoConverter.MapToDoctorDto(doctor);
            return Ok(doctorDto);
        }
        [HttpPost("/doctors/id")]
        public async Task<IActionResult> addDoctor(Doctor doctor)
        {
            var doctors = await _context.Doctors.ToListAsync();
            Doctor doctorToAdd = null;
            foreach (var d in doctors)
            {
                if (d.FirstName == doctor.FirstName && d.LastName == doctor.LastName && d.Email == doctor.Email)
                    doctorToAdd = d;
            }
            if (doctorToAdd != null)
                return BadRequest("Doctor already exists");
            await _context.Doctors.AddAsync(new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            });
            _context.SaveChanges();
            return Ok("Doctor's been added");
        }
        [HttpPut("/doctors/id")]
        public async Task<IActionResult> updateDoctor(Doctor doctor)
        {
            var d = await _context.Doctors.FindAsync(doctor.IdDoctor);
            if (d == null)
                return BadRequest("Doctor not found");
            else
            {
                d.FirstName = doctor.FirstName;
                d.LastName = doctor.LastName;
                d.Email = doctor.Email;
                _context.SaveChanges();
            }
            return Ok("Doctor's been updated");
        }
        [HttpDelete("/doctors/id")]
        public async Task<IActionResult> deleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
                _context.Doctors.Remove(doctor);
            else
                return BadRequest("Doctor not found");
            return Ok("Doctor's been deleted");
        }
        [HttpGet("/prescription/id")]
        public async Task<IActionResult> getPrescription(int id)
        {

            var prescriptions = await _context.Prescriptions
                .Include(c => c.Doctor)
                .Include(c => c.Patient)
                .Include(c => c.Prescriptions_Medicament)
                .ToListAsync();
            PrescriptionDto prescriptionDto = null;
            foreach (var p in prescriptions)
            {
                if (p.IdPrescription == id)
                {
                    prescriptionDto = DtoConverter.MapToPrescriptionDto(p);
                }
            }
            if (prescriptionDto != null)
            {
                return Ok(prescriptionDto);
            }
            else
                return BadRequest("Prescription not found");
            return Ok();
        }
    }
}
