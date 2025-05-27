using TiendaMaquillajeApp.Components;
using Microsoft.EntityFrameworkCore;
using TiendaMaquillajeApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext
builder.Services.AddDbContext<TiendaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaConnection")));

// Servicios
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IVentaService, VentaService>(); // 👈 Nuevo servicio para Ventas

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
