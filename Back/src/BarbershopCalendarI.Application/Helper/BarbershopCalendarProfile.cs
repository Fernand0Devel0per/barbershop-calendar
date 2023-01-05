using AutoMapper;
using BarbershopCalendar.Application.Dtos.Appointment;
using BarbershopCalendar.Application.Dtos.DayAppointment;
using BarbershopCalendar.Application.Dtos.Status;
using BarbershopCalendar.Application.Dtos.TypeOfWork;
using BarbershopCalendar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Application.Helper
{
    public class BarbershopCalendarProfile : Profile
    {

        public BarbershopCalendarProfile()
        {
            CreateMap<DayAppointment, DayAppointmentDto>().ReverseMap();
            CreateMap<DayAppointment, DayAppointmentOnlyDayDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<TypeOfWork, TypeOfWorkDto>().ReverseMap();
        }
        
    }
}
