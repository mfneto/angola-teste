using ClinicaVivaEstetica.Domain.Schedule;
using ClinicaVivaEstetica.Domain.Service;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicaVivaEstetica.Infrastructure.EntityFrameworkDataAccess
{
    using Microsoft.EntityFrameworkCore;
    using ClinicaVivaEstetica.Domain.Customers;
    using ClinicaVivaEstetica.Domain.ValueObjects;

    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var nameConverter = new ValueConverter<Name, string>(
                v => v.Text,
                v => new Name(v));

            var celPhoneConverter = new ValueConverter<Celphone, string>(
                v => v.Text,
                v => new Celphone(v));

            var documentConverter = new ValueConverter<Document, string>(
                v => v.Text,
                v => new Document(v));
            
            
            //Customer
            modelBuilder.Entity<Customer>()
                   .ToTable("Customer");
            
            modelBuilder.Entity<Customer>().Property(e => e.Name)
                .HasConversion(nameConverter);

            modelBuilder.Entity<Customer>().Property(e => e.Celphone)
                .HasConversion(celPhoneConverter);

            modelBuilder.Entity<Customer>().Property(e => e.Document)
                .HasConversion(documentConverter);

            modelBuilder.Entity<Customer>()
                .HasMany(m => m.Schedules)
                .WithOne(o => o.Customer)
                .OnDelete(DeleteBehavior.Cascade);
            //

            //Service
            modelBuilder.Entity<Service>()
                .ToTable("Service");
            
            modelBuilder.Entity<Service>().Property(e => e.Name)
                .HasConversion(nameConverter);

            modelBuilder.Entity<Service>()
                .HasMany(m => m.Schedules)
                .WithOne(o => o.Service)
                .OnDelete(DeleteBehavior.Cascade);
            //

            //Schedule
            modelBuilder.Entity<Schedule>()
                .ToTable("Schedules");
            //
        }
    }
}
