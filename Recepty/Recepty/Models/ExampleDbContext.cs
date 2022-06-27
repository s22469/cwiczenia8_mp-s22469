using Microsoft.EntityFrameworkCore;
using System;

namespace Recepty.Models
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescriptions_Medicament { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s22469;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.Email);
                entity.HasData(
                    new Doctor
                    { IdDoctor = 1, FirstName = "Pawel", LastName = "Konieczny", Email = "pawel@gmail.com" },
                    new Doctor { IdDoctor = 2, FirstName = "Aneta", LastName = "Kowalska", Email = "anetka@gmail.com" });
                    });
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);
                entity.Property(e => e.Name);
                entity.Property(e => e.Description);
                entity.Property(e => e.Type);
                entity.HasData(
                    new Medicament { IdMedicament = 1, Name = "Ibuprom", Description = "Max", Type = "przeciwbolowy" },
                    new Medicament { IdMedicament = 2, Name = "Stoperan", Description = "Ultra", Type = "wiadomo" },
                    new Medicament { IdMedicament = 3, Name = "Witamina C", Description = "Mega", Type = "profilaktyka" });
            });
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.Birthdate);
                entity.HasData(
                    new Patient { IdPatient = 1, FirstName = "Marta", LastName = "Wolowska", Birthdate = DateTime.Parse("13-06-2001") },
                    new Patient { IdPatient = 2, FirstName = "Goscia", LastName = "Andrzejewicz", Birthdate = DateTime.Parse("20-09-1998") },
                    new Patient { IdPatient = 3, FirstName = "Piotr", LastName = "Chimera", Birthdate = DateTime.Parse("13-05-2016") });
            });
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription);
                entity.Property(e => e.Date);
                entity.Property(e => e.DueDate);
                entity.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                entity.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);
                entity.HasData(
                    new Prescription { IdPrescription = 1, Date = DateTime.Parse("20-11-2020"), DueDate = DateTime.Parse("20-12-2020"),
                        IdPatient = 1, IdDoctor = 2 });
            });
            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);
                entity.HasKey(e => e.IdPrescription);
                entity.Property(e => e.Dose);
                entity.Property(e => e.Details);
                entity.HasOne(e => e.Medicament).WithMany(e => e.Prescriptions_Medicament).HasForeignKey(e => e.IdMedicament);
                entity.HasOne(e => e.Prescription).WithMany(e => e.Prescriptions_Medicament).HasForeignKey(e => e.IdPrescription);
                entity.HasData(
                    new Prescription_Medicament { IdMedicament = 2, IdPrescription = 1, Dose = 3, Details = "codziennie" });
            });
        }
    }
}
