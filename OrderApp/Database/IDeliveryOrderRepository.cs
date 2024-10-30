using OrderApp.Models;

namespace OrderApp.Database;

public interface IDeliveryOrderRepository
{
	Task DeleteAllOrders();
	Task AddFiltredOrders(List<Order> orders);
}