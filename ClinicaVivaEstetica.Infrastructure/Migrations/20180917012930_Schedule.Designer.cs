﻿// <auto-generated />
using System;
using ClinicaVivaEstetica.Infrastructure.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicaVivaEstetica.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20180917012930_Schedule")]
    partial class Schedule
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicaVivaEstetica.Domain.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Celphone");

                    b.Property<string>("Document");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ClinicaVivaEstetica.Domain.Schedule.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CustomerId");

                    b.Property<DateTime>("Day");

                    b.Property<TimeSpan>("Hour");

                    b.Property<Guid?>("ServiceId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ClinicaVivaEstetica.Domain.Service.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowHalfTime");

                    b.Property<string>("Name");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("ClinicaVivaEstetica.Domain.Schedule.Schedule", b =>
                {
                    b.HasOne("ClinicaVivaEstetica.Domain.Customers.Customer", "Customer")
                        .WithMany("Schedules")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClinicaVivaEstetica.Domain.Service.Service", "Service")
                        .WithMany("Schedules")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
