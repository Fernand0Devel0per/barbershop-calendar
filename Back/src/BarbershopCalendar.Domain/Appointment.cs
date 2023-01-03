using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Domain
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime? TimeAppointment { get; set; }

        public TypeOfWork? Service { get; set; }

        public Status Status { get; set; }

        public string ClientName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
