using Microsoft.EntityFrameworkCore;
using WebApplicationPokemon.Models;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi il DbContext e collega al DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ... configurazioni HTTP già pronte ...
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Trainer}/{action=Index}/{id?}");

app.Run();
