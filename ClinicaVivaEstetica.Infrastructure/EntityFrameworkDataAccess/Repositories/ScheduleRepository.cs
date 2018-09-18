using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Repositories.Schedule;
using ClinicaVivaEstetica.Domain;
using ClinicaVivaEstetica.Domain.Schedule;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVivaEstetica.Infrastructure.EntityFrameworkDataAccess.Repositories
{
    public class ScheduleRepository : IScheduleReadOnlyRepository, IScheduleWriteOnlyRepository
    {
        private readonly Context _context;

        public ScheduleRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            int affectedRows = await _context.SaveChangesAsync();
        }

        public async Task<Schedule> Get(Guid id)
        {
            Schedule schedule = await _context.Schedules.FindAsync(id);

            if (schedule == null)
                throw new ClinicaVivaEsteticaException($"O agendamento {id} não existe ou ainda não foi processado.");

            return schedule;
        }

        public async Task Update(Schedule schedule)
        {
            _context.Entry(schedule).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Schedule schedule)
        {
            _context.Entry(schedule).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}