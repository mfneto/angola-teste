using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Repositories.Customer;
using ClinicaVivaEstetica.Domain;
using ClinicaVivaEstetica.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVivaEstetica.Infrastructure.EntityFrameworkDataAccess.Repositories
{
    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            int affectedRows = await _context.SaveChangesAsync();
        }

        public async Task<Customer> Get(Guid id)
        {
            Customer customer = await _context.Customers.FindAsync(id);

            if (customer == null)
                throw new ClinicaVivaEsteticaException($"O cliente {id} não existe ou ainda não foi processado.");

            return customer;
        }

        public async Task Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
