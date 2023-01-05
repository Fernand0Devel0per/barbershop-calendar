using BarbershopCalendar.Domain;
using BarbershopCalendar.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Persistence.Interface
{
    public class DayAppointmentPersist : IDayAppointmentPersist
    {
        private readonly BarbershopContext _barbershopContext;

        public DayAppointmentPersist(BarbershopContext barbershopContext)
        {
            _barbershopContext = barbershopContext;
        }

        public async Task<DayAppointment[]> GetAllDayAppointmentsAsync()
        {
            IQueryable<DayAppointment> query = (IQueryable<DayAppointment>) _barbershopContext.
                DaysAppointment.
                AsNoTracking().
                Include(dayApp => dayApp.Appointments);

            return await query.ToArrayAsync();
        }

        public async Task<DayAppointment> GetDayAppointmentByIdAsync(int dayAppointmentId)
        {
            IQueryable<DayAppointment> query = (IQueryable<DayAppointment>)_barbershopContext.
                DaysAppointment.
                AsNoTracking().
                Where(dayApp => dayApp.Id == dayAppointmentId).
                Include(dayApp => dayApp.Appointments);

            return await query.FirstOrDefaultAsync();
        }
    }
}
