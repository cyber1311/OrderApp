namespace OrderApp.Database;
using Dapper;
using OrderApp.Models;
using Npgsql;
public class DeliveryOrderRepository : IDeliveryOrderRepository
{
	private readonly string _connectionString;
	private readonly ILogsRepository _logger;

	private const string InsertIntoDeliveryOrderCommand =
		@"insert into delivery_order(id, weight, district, delivery_time) VALUES(@Id, @Weight, @District, @DeliveryTime);";

	private const string DeleteAllOrdersCommand =
		@"delete from delivery_order;";


	public DeliveryOrderRepository(IConfiguration configuration, ILogsRepository logger)
	{
		_connectionString = configuration.GetValue<string>("Database:ConnectionString");
		_logger = logger;
	}

	public async Task DeleteAllOrders(){
		await using var connection = new NpgsqlConnection(_connectionString);
		await connection.OpenAsync();
		await connection.ExecuteAsync(DeleteAllOrdersCommand);
	}
	public async Task AddFiltredOrders(List<Order> orders){
		try{
			await DeleteAllOrders();
			await using var connection = new NpgsqlConnection(_connectionString);
			await connection.OpenAsync();
			await using var transaction = await connection.BeginTransactionAsync();
			foreach (var order in orders)
			{
				await connection.ExecuteAsync(InsertIntoDeliveryOrderCommand, new
				{
					@Id = order.Id,
					@Weight = order.Weight,
					@District = order.District,
					@DeliveryTime = order.DeliveryTime
				}, transaction: transaction);
			}
			await transaction.CommitAsync();
			await _logger.AddLog(new Log
			{
				Id = Guid.NewGuid(),
				Type = "Infomation",
				Message = $"Отфильтрованные заказы добавлены в таблицу delivery_order",
				Time = DateTime.Now
			});
		}
		catch(Exception)
		{
			await _logger.AddLog(new Log
			{
				Id = Guid.NewGuid(),
				Type = "Error",
				Message = $"Ошибка добавления отфильтрованных заказов в таблицу delivery_order",
				Time = DateTime.Now
			});
		}
	}


}