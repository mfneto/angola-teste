using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Repositories.Service;
using ClinicaVivaEstetica.Domain;
using ClinicaVivaEstetica.Domain.Service;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVivaEstetica.Infrastructure.EntityFrameworkDataAccess.Repositories
{
    public class ServiceRepository : IServiceReadOnlyRepository, IServiceWriteOnlyRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Service service)
        {
            await _context.Services.AddAsync(service);
            int affectedRows = await _context.SaveChangesAsync();
        }

        public async Task<Service> Get(Guid id)
        {
            Service service = await _context.Services.FindAsync(id);

            if (service == null)
                throw new ClinicaVivaEsteticaException($"O serviço {id} não existe ou ainda não foi processado.");

            return service;
        }

        public async Task Update(Service service)
        {
            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Service service)
        {
            _context.Entry(service).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}