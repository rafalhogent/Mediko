using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedikoData.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedikoData.Repos
{
    public class SQLLogBookRepo : ILogBookRepo
    {
        private MedikoDbContext _context;
        public SQLLogBookRepo(MedikoDbContext context)
        {
            _context = context;
        }

        public async Task AddNewLogBook(LogBook logbook)
        {
            await _context.LogBooks.AddAsync(logbook);
            _context.SaveChanges();
        }

        public async Task DeleteLogBook(int id)
        {
            var logbook = await _context.LogBooks.FindAsync(id);
            if (logbook != null)
            {
                _context.LogBooks.Remove(logbook);
                _context.SaveChanges();
            }
        }

        public async Task<LogBook?> GetLogBookById(int? id)
        {
            if (id == null || _context.LogBooks == null)
            {
                return null;
            }

            return await _context.LogBooks.FindAsync(id);



        }

        public async Task<IEnumerable<LogBook>> GetLogBooksForUser(string userId)
        {
            return await _context.LogBooks
                .Where(x => x.Creator == null || x.Creator.Id == userId).ToListAsync();
        }

        public async Task Update(LogBook logBook)
        {
            _context.Update(logBook);
            await _context.SaveChangesAsync();
        }
    }
}
