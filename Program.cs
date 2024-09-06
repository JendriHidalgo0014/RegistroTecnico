using RegistroTecnico.Components;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using RegistroTecnico.Components;
using Microsoft.EntityFrameworkCore;
using REGISTROTECNICO.Service;

var builder = WebApplication.CreateBuilder(args);

// Inyeccion SqLite
var ConStr = builder.Configuration.GetConnectionString("ConStr"); 
builder.Services.AddDbContext<Context>(c => c.UseSqlite(ConStr));

// Inyeccion Service
builder.Services.AddScoped<TecnicoService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
