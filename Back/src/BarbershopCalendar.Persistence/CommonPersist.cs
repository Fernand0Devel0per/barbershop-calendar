using BarbershopCalendar.Persistence.DataContext;
using BarbershopCalendar.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Persistence
{
    public class CommonPersist : ICommonPersist
    {
        private readonly BarbershopContext _barbershopContext;

        public CommonPersist(BarbershopContext barbershopContext)
        {
            _barbershopContext = barbershopContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _barbershopContext.Add(entity);
        }

        public void Updade<T>(T entity) where T : class
        {
            _barbershopContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _barbershopContext.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _barbershopContext.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _barbershopContext.SaveChangesAsync()) > 0;
        }
    }
}
