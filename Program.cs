using DHL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Pøidání služeb pro Razor Pages
builder.Services.AddRazorPages();

// Konfigurace pøipojení k SQL Serveru (zmìò connection string podle potøeby)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Pøidání autentizace a autorizace (pokud bude potøeba)
builder.Services.AddAuthorization();
builder.Services.AddControllers(); // Pøidání API Controllerù
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Sestavení aplikace
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

app.UseSwagger();
app.UseSwaggerUI();
app.Run();
