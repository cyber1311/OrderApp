namespace OrderApp.Database;
using Dapper;
using OrderApp.Models;
using Npgsql;
public class OrdersRepository : IOrdersRepository
{
	private readonly string _connectionString;
	private readonly ILogsRepository _logger;

	private const string InsertIntoOrdersCommand =
		@"insert into orders(id, weight, district_id, delivery_time) VALUES(@Id, @Weight, (select id from districts where name = @Name), @DeliveryTime);";

	private const string GetAllOrdersCommand =
		@"select orders.id as Id, weight as Weight, name as District, delivery_time as DeliveryTime from orders inner join districts on orders.district_id = districts.id;";

	private const string GetFilteredOrdersCommand =
		@"select orders.id as Id, weight as Weight, name as District, delivery_time as DeliveryTime from orders inner join districts on orders.district_id = districts.id where name = @Name and delivery_time between @DeliveryTime and @DeliveryTime + interval '30 minute';";

	private const string GetAllDistrictsCommand =
			@"select name as Name from districts;";


	public OrdersRepository(IConfiguration configuration, ILogsRepository logger)
	{
		_connectionString = configuration.GetValue<string>("Database:ConnectionString");
		_logger = logger;
	}

	public async Task AddOrder(Order order){
		try
		{
			await using var connection = new NpgsqlConnection(_connectionString);
			await connection.OpenAsync();
			await connection.ExecuteAsync(InsertIntoOrdersCommand, new
			{
				@Id = order.Id,
				@Weight = order.Weight,
				@Name = order.District,
				@DeliveryTime = order.DeliveryTime
			});
			await _logger.AddLog(new Log{
				Id = Guid.NewGuid(),
				Type = "Infomation",
				Message = $"Заказ {order.Id} добавлен в таблицу order",
				Time = DateTime.Now
			});
		}
		catch (Exception)
		{
			await _logger.AddLog(new Log
			{
				Id = Guid.NewGuid(),
				Type = "Error",
				Message = $"Ошибка добавления заказа {order.Id}  в таблицу order",
				Time = DateTime.Now
			});
		}

		return;
	}
	public async Task<List<Order>> GetOrders(){
		List<Order> lists = new();
		try{
			await using var connection = new NpgsqlConnection(_connectionString);
			await connection.OpenAsync();
			var result = await connection.QueryAsync<Order>(GetAllOrdersCommand);
			lists = result.ToList();
		}
		catch (Exception)
		{
			await _logger.AddLog(new Log
			{
				Id = Guid.NewGuid(),
				Type = "Error",
				Message = "Ошибка получения списка заказов из таблицы order",
				Time = DateTime.Now
			});
		}
		return lists;
	}
	public async Task<List<Order>> GetFilteredOrders(string _cityDistrict, DateTime _firstDeliveryDateTime){
		List<Order> lists = new();
		try
		{
			await using var connection = new NpgsqlConnection(_connectionString);
			await connection.OpenAsync();
			var result = await connection.QueryAsync<Order>(GetFilteredOrdersCommand, new{
				@Name = _cityDistrict,
				@DeliveryTime = _firstDeliveryDateTime
			});
			lists = result.ToList();
			await _logger.AddLog(new Log
			{
				Id = Guid.NewGuid(),
				Type = "Infomation",
				Message = $"Заказы отфильтрованы. Район - {_cityDistrict}. Время первой доставки - {_firstDeliveryDateTime}",
				Time = DateTime.Now
			});
		}
		catch (Exception)
		{
			await _logger.AddLog(new Log
			{
				Id = Guid.NewGuid(),
				Type = "Error",
				Message = $"Ошибка при фильтрации заказов. Район - {_cityDistrict}. Время первой доставки - {_firstDeliveryDateTime}",
				Time = DateTime.Now
			});
		}
		return lists;
	}

	public async Task<List<District>> GetDistricts(){
		List<District> lists = new();
		await using var connection = new NpgsqlConnection(_connectionString);
		await connection.OpenAsync();
		var result = await connection.QueryAsync<District>(GetAllDistrictsCommand);
		lists = result.ToList();
		return lists;
	}


}