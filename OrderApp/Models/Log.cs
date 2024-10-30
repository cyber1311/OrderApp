namespace OrderApp.Models;
public class Log
{
	public Guid Id { get; set; }
	public string Type { get; set; } = "";

	public string Message { get; set; } = "";
	public DateTime Time { get; set; }
}