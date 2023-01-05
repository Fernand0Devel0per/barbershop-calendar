using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Domain
{
    public class DayAppointment
    {
        public int Id { get; set; }

        public string WeekDay { get; set; }

        public DateTime Date { get; set; }

        public bool IsAvailable { get; set; }

        public IEnumerable<Appointment>? Appointments { get; set; }

    }

}
