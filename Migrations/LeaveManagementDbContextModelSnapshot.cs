﻿// <auto-generated />
using System;
using LeaveApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeaveApplication.Migrations
{
    [DbContext(typeof(LeaveManagementDbContext))]
    partial class LeaveManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LeaveApplication.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 5,
                            FirstName = "Vicky",
                            LastName = "Walle"
                        },
                        new
                        {
                            EmployeeId = 6,
                            FirstName = "Nelly",
                            LastName = "Nordlund"
                        },
                        new
                        {
                            EmployeeId = 7,
                            FirstName = "Melissa",
                            LastName = "Wallström"
                        });
                });

            modelBuilder.Entity("LeaveApplication.Models.LeaveForm", b =>
                {
                    b.Property<int>("LeaveApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaveApplicationId"));

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FkEmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("LeaveApplicationId");

                    b.HasIndex("FkEmployeeId");

                    b.ToTable("LeaveForms");

                    b.HasData(
                        new
                        {
                            LeaveApplicationId = 1,
                            ApplicationDate = new DateTime(2024, 4, 11, 14, 23, 19, 774, DateTimeKind.Local).AddTicks(327),
                            EndDate = new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FkEmployeeId = 5,
                            StartDate = new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 1
                        },
                        new
                        {
                            LeaveApplicationId = 6,
                            ApplicationDate = new DateTime(2024, 4, 11, 14, 23, 19, 774, DateTimeKind.Local).AddTicks(393),
                            EndDate = new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FkEmployeeId = 6,
                            StartDate = new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 0
                        },
                        new
                        {
                            LeaveApplicationId = 4,
                            ApplicationDate = new DateTime(2024, 4, 11, 14, 23, 19, 774, DateTimeKind.Local).AddTicks(396),
                            EndDate = new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FkEmployeeId = 7,
                            StartDate = new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 0
                        });
                });

            modelBuilder.Entity("LeaveApplication.Models.LeaveForm", b =>
                {
                    b.HasOne("LeaveApplication.Models.Employee", "Employee")
                        .WithMany("LeaveForms")
                        .HasForeignKey("FkEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("LeaveApplication.Models.Employee", b =>
                {
                    b.Navigation("LeaveForms");
                });
#pragma warning restore 612, 618
        }
    }
}
