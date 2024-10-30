using OrderApp.Models;

namespace OrderApp.Database;

public interface ILogsRepository
{
	Task AddLog(Log log);
	Task<List<Log>> GetLogs();
}