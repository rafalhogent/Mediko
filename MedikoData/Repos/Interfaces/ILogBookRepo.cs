﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedikoData.Entities;

namespace MedikoData.Repos
{
    public interface ILogBookRepo
    {
        Task AddNewLogBook(LogBook logbook);
        Task DeleteLogBook(int id);
        Task<LogBook?> GetLogBookById(int? id);
        Task<IEnumerable<LogBook>> GetLogBooksForUser(string userId);
        Task Update(LogBook logBook);
    }
}
