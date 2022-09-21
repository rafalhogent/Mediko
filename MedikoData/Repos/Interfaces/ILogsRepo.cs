using MedikoData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedikoData.Repos
{
    public interface ILogsRepo
    {
        Task<bool> AddNewLogAsync(int logBookId, string userId, DateTime logTime, float? value1, float? value2, float? value3, string? comment);
        Task<Log?> GetLogByIdAsync(int logId);
        Task<IEnumerable<Log>> GetUserLogsByLogbookIdAsync(string userId, int logbookId);
        Task<bool> RemoveLogAsync(Log log);
    }
}
