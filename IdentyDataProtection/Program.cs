using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using IdentityDataProtectionApp.Data;
using IdentityDataProtectionApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddDataProtection();
builder.Services.AddScoped<EncryptionService>();

// Swagger ekleme
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Identity Data Protection API",
        Version = "v1",
        Description = "API for managing users with encryption and validation.",
        Contact = new OpenApiContact
        {
            Name = "Ahmet Emre Arı",
            Email = "info@aemreari.com",
            Url = new Uri("https://www.aemreari.com")
        }
    });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity Data Protection API V1");
        c.RoutePrefix = string.Empty; // Swagger UI kök URL'de çalışsın
    });
}

app.UseRouting();
app.MapControllers();

app.Run();
