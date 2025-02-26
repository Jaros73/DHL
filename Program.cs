using DHL.Data;
//using DHL.Services;
//using DHL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("DHLApiClient", client =>
{
    client.BaseAddress = new Uri("https://dhl.cpost.cz");
});


// Pøidání databáze (napø. SQLite nebo SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrace služeb (Business Logic)
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IAuthService, AuthService>();

// Registrace repository (pøístup k DB)
//builder.Services.AddScoped<IUserRepository, UserRepository>();

// Pøidání Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
