using Microsoft.EntityFrameworkCore;
using PrescriptionManagement.Data;
using PrescriptionManagement.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

// Middlewares
app.UseAuthorization();

app.MapControllers();

app.Run();