using BarbershopCalendar.Application.Dtos.DayAppointment;
using BarbershopCalendar.Application.Dtos.Status;
using BarbershopCalendar.Application.Dtos.TypeOfWork;
using BarbershopCalendar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Application.Dtos.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public DateTime? TimeAppointment { get; set; }

        public string? ClientName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public TypeOfWorkDto? TypeOfWork { get; set; }

        public int? TypeOfWorkId { get; set; }

        public StatusDto? Status { get; set; }

        public int StatusId { get; set; }

        public DayAppointmentDto? DayAppointment { get; set; }

        public int? DayAppointmentId { get; set; }
    }
}
