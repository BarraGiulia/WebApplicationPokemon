using Microsoft.EntityFrameworkCore;
using WebApplicationPokemon.Models;


var builder = WebApplication.CreateBuilder(args);

// Aggiungi il DbContext e collega al DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache(); // necessario per la sessione
builder.Services.AddHttpContextAccessor(); // prima di builder.Build()

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5002); // Aggiunto per IP LAN su porta 5002
});

var app = builder.Build();

// ... configurazioni HTTP già pronte ...
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
