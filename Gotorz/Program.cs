using Gotorz.Components;
using Gotorz.Data;
using Gotorz.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;



var builder = WebApplication.CreateBuilder(args);


//Changes the dateTime format to a proper format
var culture = new CultureInfo("da-DK");
CultureInfo.CurrentCulture = culture;
CultureInfo.CurrentUICulture = culture;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AuthStateService>();
builder.Services.AddScoped<TravelAPIService>();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

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
