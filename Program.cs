using DHL.Data;
//using DHL.Services;
//using DHL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("DHLApiClient", client =>
{
    client.BaseAddress = new Uri("https://dhl.cpost.cz");
});


// P�id�n� datab�ze (nap�. SQLite nebo SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrace slu�eb (Business Logic)
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IAuthService, AuthService>();

// Registrace repository (p��stup k DB)
//builder.Services.AddScoped<IUserRepository, UserRepository>();

// P�id�n� Razor Pages
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
