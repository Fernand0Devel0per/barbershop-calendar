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
    public class DayAppointment : IDayAppointment
    {
        private readonly BarbershopContext _barbershopContext;

        public DayAppointment(BarbershopContext barbershopContext)
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
    }
}
