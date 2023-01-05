﻿using BarbershopCalendar.Application.Dtos.DayAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Application.Interface
{
    public interface IDayAppointmentService
    {
        Task<DayAppointmentDto> AddDayAppointmentDto(DayAppointmentDto model);

        Task<DayAppointmentDto> UpdateDayAppointmentDto(int dayAppointmentId, DayAppointmentDto model);

        Task<bool> DeleteDayAppointmentDto(int dayAppointmentId);

        Task<DayAppointmentDto[]> GetDayAppointmentDtoByPageAsync();

        Task<DayAppointmentDto> GetDayAppointmentDtoByIdAsync(int dayAppointmentId);
    }
}
