using Microsoft.EntityFrameworkCore;
using project_venda_api.Data.Context;
using project_venda_api.Services; // IMPORTANTE

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Registrar a CLASSE
builder.Services.AddScoped<BoletoService>();

Console.WriteLine("Base Directory:");
Console.WriteLine(AppContext.BaseDirectory);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
