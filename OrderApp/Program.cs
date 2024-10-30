using OrderApp.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IOrdersRepository, OrdersRepository>();
builder.Services.AddSingleton<ILogsRepository, LogsRepository>();
builder.Services.AddSingleton<IDeliveryOrderRepository, DeliveryOrderRepository>();
builder.Services.AddControllersWithViews();


var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Index}");

app.Run();
