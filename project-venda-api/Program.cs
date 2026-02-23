using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using project_venda_api.Data.Context;
using project_venda_api.Services; // IMPORTANTE

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//registrar a classe
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
app.UseCors("AllowFrontend");

var pastaBoletos = @"C:\cnesistemas\Boletos";

// Garante que a pasta existe
if (!Directory.Exists(pastaBoletos))
{
    Directory.CreateDirectory(pastaBoletos);
}

// Depois configura os arquivos estáticos
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(pastaBoletos),
    RequestPath = "/boletos"
});

app.Run();
