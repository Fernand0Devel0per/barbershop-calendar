using BarbershopCalendar.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Persistence.Interface
{
    public interface IDayAppointmentPersist
    {
        Task<DayAppointment[]> GetAllDayAppointmentsAsync();

        Task<DayAppointment> GetDayAppointmentByIdAsync(int dayAppointmentId);

        Task<DayAppointment> GetDayAppointmentByDateAsync(string date);
    }
}
