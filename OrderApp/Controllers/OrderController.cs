using Microsoft.AspNetCore.Mvc;
using OrderApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderApp.Database;

namespace OrderApp.Controllers;

public class OrderController : Controller
{
	private readonly IConfiguration _configuration;
	private readonly IOrdersRepository _ordersRepository;
	private readonly IDeliveryOrderRepository _deliveryOrderRepository;
	public OrderController(IConfiguration configuration, IOrdersRepository ordersRepository, IDeliveryOrderRepository deliveryOrderRepository)
    {
		_configuration = configuration;
		_ordersRepository = ordersRepository;
		_deliveryOrderRepository = deliveryOrderRepository;

	}

	public async Task<ActionResult> Create()
	{
		List<District> districts = await _ordersRepository.GetDistricts(); 
		ViewBag.Districts = new SelectList(districts, "Name", "Name");
		return View();
	}

	[HttpPost]
	public async Task<ActionResult> Create(Order order)
	{
		if (ModelState.IsValid)
		{
			order.Id = Guid.NewGuid();
			await _ordersRepository.AddOrder(order);
			return RedirectToAction("Index");
		}
		List<District> districts = await _ordersRepository.GetDistricts();
		ViewBag.Districts = new SelectList(districts, "Name", "Name", order.District);
		return View(order);
	}


	public async Task<IActionResult> Index(string district, DateTime? firstDeliveryDateTime)
    {
		List<District> districts = await _ordersRepository.GetDistricts();
		ViewBag.Districts = new SelectList(districts, "Name", "Name");
		List<Order> orders = await _ordersRepository.GetOrders();

		if (string.IsNullOrEmpty(district) && !firstDeliveryDateTime.HasValue)
		{
			district = _configuration.GetValue<string>("_cityDistrict");
			firstDeliveryDateTime = _configuration.GetValue<DateTime?>("_firstDeliveryDateTime");
		}

		if (!string.IsNullOrEmpty(district) && firstDeliveryDateTime.HasValue)
		{
			orders = await _ordersRepository.GetFilteredOrders(district, firstDeliveryDateTime.Value);
			await _deliveryOrderRepository.AddFiltredOrders(orders);
		}
		
		ViewData["District"] = district;
		ViewData["FirstDeliveryDateTime"] = firstDeliveryDateTime;

		return View(orders);
    }
}
