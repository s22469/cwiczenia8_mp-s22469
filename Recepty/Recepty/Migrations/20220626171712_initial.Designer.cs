﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recepty.Models;

namespace Recepty.Migrations
{
    [DbContext(typeof(ExampleDbContext))]
    [Migration("20220626171712_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Recepty.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "pawel@gmail.com",
                            FirstName = "Pawel",
                            LastName = "Konieczny"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "anetka@gmail.com",
                            FirstName = "Aneta",
                            LastName = "Kowalska"
                        });
                });

            modelBuilder.Entity("Recepty.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Max",
                            Name = "Ibuprom",
                            Type = "przeciwbolowy"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Ultra",
                            Name = "Stoperan",
                            Type = "wiadomo"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Description = "Mega",
                            Name = "Witamina C",
                            Type = "profilaktyka"
                        });
                });

            modelBuilder.Entity("Recepty.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(2001, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Marta",
                            LastName = "Wolowska"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(1998, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Goscia",
                            LastName = "Andrzejewicz"
                        },
                        new
                        {
                            IdPatient = 3,
                            Birthdate = new DateTime(2016, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Piotr",
                            LastName = "Chimera"
                        });
                });

            modelBuilder.Entity("Recepty.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 2,
                            IdPatient = 1
                        });
                });

            modelBuilder.Entity("Recepty.Models.Prescription_Medicament", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dose")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdMedicament");

                    b.ToTable("Prescriptions_Medicament");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Details = "codziennie",
                            Dose = 3,
                            IdMedicament = 2
                        });
                });

            modelBuilder.Entity("Recepty.Models.Prescription", b =>
                {
                    b.HasOne("Recepty.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recepty.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Recepty.Models.Prescription_Medicament", b =>
                {
                    b.HasOne("Recepty.Models.Medicament", "Medicament")
                        .WithMany("Prescriptions_Medicament")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recepty.Models.Prescription", "Prescription")
                        .WithMany("Prescriptions_Medicament")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Recepty.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Recepty.Models.Medicament", b =>
                {
                    b.Navigation("Prescriptions_Medicament");
                });

            modelBuilder.Entity("Recepty.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Recepty.Models.Prescription", b =>
                {
                    b.Navigation("Prescriptions_Medicament");
                });
#pragma warning restore 612, 618
        }
    }
}
