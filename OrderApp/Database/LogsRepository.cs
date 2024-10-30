namespace OrderApp.Database;
using Dapper;
using OrderApp.Models;
using Npgsql;

public class LogsRepository : ILogsRepository{
	private readonly string _connectionString;

	private const string InsertIntoLogsCommand =
		@"insert into delivery_log(id, type, message, time) VALUES(@Id, @Type, @Message, @Time);";

	private const string GetAllLogsCommand =
		@"select id as Id, type as Type, message as Message, time as Time from delivery_log;";

	public LogsRepository(IConfiguration configuration)
	{
		_connectionString = configuration.GetValue<string>("Database:ConnectionString");
	}

	public async Task AddLog(Log log)
	{
		await using var connection = new NpgsqlConnection(_connectionString);
		await connection.OpenAsync();
		await connection.ExecuteAsync(InsertIntoLogsCommand, new
		{
			@Id = log.Id,
			@Type = log.Type,
			@Message = log.Message,
			@Time = log.Time
		});

		return;
	}

	public async Task<List<Log>> GetLogs()
	{
		List<Log> lists = new();
		await using var connection = new NpgsqlConnection(_connectionString);
		await connection.OpenAsync();
		var result = await connection.QueryAsync<Log>(GetAllLogsCommand);
		lists = result.ToList();
		return lists;
	}

}