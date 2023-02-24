using Inventory_Management_System.Data;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//!Product Repository connection
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//! Database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});



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

app.MapControllerRoute(
    name: "product",
    pattern: "product/{id?}",
    defaults: new { controller = "Product", action = "Index" });

app.MapControllerRoute(
    name: "supplierDetail",
    pattern: "supplier/{id?}",
    defaults: new { controller = "SupplierDetail", action = "Index" });

app.Run();
