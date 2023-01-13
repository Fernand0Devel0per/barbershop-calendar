using BarbershopCalendar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Application.Dtos.DayAppointment
{
    public class DayAppointmentOnlyDayDto
    {
        public int Id { get; set; }

        public string WeekDay { get; set; }

        public string Date { get; set; }

        public bool IsAvailable { get; set; }
    }
}
