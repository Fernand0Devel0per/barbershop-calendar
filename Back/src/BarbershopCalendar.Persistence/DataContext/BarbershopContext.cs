using BarbershopCalendar.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Persistence.DataContext
{
    public class BarbershopContext : DbContext
    {

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<DayAppointment> DaysAppointment { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<TypeOfWork> TypesOfWork { get; set; }

        public BarbershopContext(DbContextOptions<BarbershopContext> options) : base(options)
        {

        }
    }
}
