using BarbershopCalendar.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Persistence.Interface
{
    public interface IDayAppointment
    {
        Task<DayAppointment[]> GetAllDayAppointmentsAsync();

        Task<DayAppointment> GetDayAppointmentIdAsync(int dayAppointmentId)
    }
}
