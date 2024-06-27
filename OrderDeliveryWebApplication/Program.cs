using Microsoft.EntityFrameworkCore;
using OrderDeliveryWebApplication.Data;
using OrderDeliveryWebApplication.Data.Repositories;
using OrderDeliveryWebApplication.Domain.Repositories;
using OrderDeliveryWebApplication.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

var dbConnection = builder.Configuration.GetConnectionString("OrderDeliveryWebApplicationContext");
if (dbConnection is null)
{
    throw new InvalidOperationException("Connection string 'OrderDeliveryWebApplicationContext' not found.");
}

builder.Services.AddDbContext<OrderDeliveryWebApplicationContext>(options => options.UseSqlServer(dbConnection));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();
builder.Services.AddTransient<OrdersService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=OrderDelivery}/{action=Index}/{id?}");

await app.RunAsync();