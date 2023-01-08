using BarbershopCalendar.Application.Dtos.DayAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Application.Interface
{
    public interface IDayAppointmentService
    {
        Task<DayAppointmentDto> AddDayAppointment(DayAppointmentDto model);

        Task<DayAppointmentDto> UpdateDayAppointment(int dayAppointmentId, DayAppointmentDto model);

        Task<bool> DeleteDayAppointmentDto(int dayAppointmentId);

        Task<DayAppointmentOnlyDayDto[]> GetDayAppointmentDtoByPageAsync(int page, int row);

        Task<DayAppointmentDto> GetDayAppointmentDtoByIdAsync(int dayAppointmentId);
    }
}
