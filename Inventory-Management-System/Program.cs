using Inventory_Management_System.Data;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//!Product Repository connection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

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
    pattern: "{controller=Home}/{action=Index}");


app.MapControllerRoute(
    name: "ProductList",
    pattern: "/{id}/{showNum?}/{searchInput?}",
    defaults: new { controller = "Product", action = "Index" });


app.MapControllerRoute(
    name: "CreateProduct",
    pattern: "/CreateProduct",
    defaults: new { controller = "Product", action = "CreateProduct" });

app.MapControllerRoute(
    name: "EditProduct",
    pattern: "/EditProduct/{id}",
    defaults: new { controller = "Product", action = "EditProduct" });

app.MapControllerRoute(
    name: "DeleteProduct",
    pattern: "/DeleteProduct/{id}/{showNum}/{searchIndex}/{productId}/",
    defaults: new { controller = "Product", action = "DeleteProduct" });


app.MapControllerRoute(
    name: "SupplierList",
    pattern: "/{id}/{showNum?}/{searchInput?}",
    defaults: new { controller = "Supplier", action = "Index" });

app.MapControllerRoute(
    name: "CreateSupplier",
    pattern: "/CreateSupplier",
    defaults: new { controller = "Supplier", action = "CreateSupplier" });


app.MapControllerRoute(
    name: "EditSupplier",
    pattern: "/EditSupplier/{id}",
    defaults: new { controller = "Supplier", action = "EditSupplier" });

app.MapControllerRoute(
    name: "DeleteSupplier",
    pattern: "/DeleteSupplier/{id}/{showNum}/{searchIndex}/{productId}/",
    defaults: new { controller = "Product", action = "DeleteSupplier" });

app.Run();
