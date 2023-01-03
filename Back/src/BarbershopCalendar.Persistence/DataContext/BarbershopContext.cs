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

        public BarbershopContext(DbContextOptions<BarbershopContext> options) : base(options)
        {

        }
    }
}
