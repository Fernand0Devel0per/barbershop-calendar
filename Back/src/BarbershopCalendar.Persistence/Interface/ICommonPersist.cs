﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopCalendar.Persistence.Interface
{
    public interface ICommonPersist
    {
        void Add<T>(T entity) where T : class;

        void Updade<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void DeleteRange<T>(T[] entityArray) where T : class;

        Task<bool> SaveChangesAsync();
    }
}
