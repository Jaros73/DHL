using DHL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// P�id�n� slu�eb pro Razor Pages
builder.Services.AddRazorPages();

// Konfigurace p�ipojen� k SQL Serveru (zm�� connection string podle pot�eby)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// P�id�n� autentizace a autorizace (pokud bude pot�eba)
builder.Services.AddAuthorization();
builder.Services.AddControllers(); // P�id�n� API Controller�
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Sestaven� aplikace
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
