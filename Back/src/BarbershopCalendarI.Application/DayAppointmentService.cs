using BarbershopCalendar.Application.Dtos.DayAppointment;
using BarbershopCalendar.Application.Interface;
using BarbershopCalendar.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Application
{
    public class DayAppointmentService : IDayAppointmentService
    {
        private readonly ICommonPersist _commonPersist;
        private readonly IDayAppointment _dayAppointment;

        public DayAppointmentService(ICommonPersist commonPersist, IDayAppointment dayAppointment)
        {
            _commonPersist = commonPersist;
            _dayAppointment = dayAppointment;
        }

        public Task<DayAppointmentDto> AddDayAppointmentDto(DayAppointmentDto model)
        {
            
        }

        public Task<bool> DeleteDayAppointmentDto(int dayAppointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<DayAppointmentDto> GetDayAppointmentDtoByIdAsync(int dayAppointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<DayAppointmentDto[]> GetDayAppointmentDtoByPageAsync(int page = 1, int row = 5)
        {
            throw new NotImplementedException();
        }

        public Task<DayAppointmentDto> UpdateDayAppointmentDto(int dayAppointmentId, DayAppointmentDto model)
        {
            throw new NotImplementedException();
        }
    }
}
