using Microsoft.EntityFrameworkCore;
using Room_Productivity.Models;
using Room_Productivity.Services;
using Room_Productivity.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//add connection with sql
builder.Services.AddDbContext<Room_ProductivityContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Room_ProductivityContext"));    
});

//inyección de depenencia
builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddScoped<IUserService, UserService>();

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
