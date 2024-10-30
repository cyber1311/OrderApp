namespace OrderApp.Models;

using System.ComponentModel.DataAnnotations;
public class Order
{
	public Guid Id { get; set; }

	[Display(Name = "Вес")]
	[Range(0, 1000, ErrorMessage = "Вес должен быть от 0 до 1000 кг.")]
	public double Weight { get; set; }

	public string District { get; set; } = "";

	public DateTime DeliveryTime { get; set; }

}