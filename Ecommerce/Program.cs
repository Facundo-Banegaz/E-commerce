
using Ecommerce.Services.Definicion;
using Ecommerce.Services.Implementacion;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var strConection = builder.Configuration.GetConnectionString("CadenaSql").ToString();

builder.Services.AddDbContext<Ecommerce.Data.EcommerceContext>(options => options.UseSqlServer(strConection));

builder.Services.AddTransient<IProductosInterface, ProductosInterface>();






// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
