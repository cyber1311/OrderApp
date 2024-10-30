using OrderApp.Models;

namespace OrderApp.Database;

public interface IOrdersRepository
{
	Task AddOrder(Order order);
	Task<List<Order>> GetOrders();
	Task<List<Order>> GetFilteredOrders(string _cityDistrict, DateTime _firstDeliveryDateTime);
	Task<List<District>> GetDistricts();
}