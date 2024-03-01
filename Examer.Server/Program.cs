using Examer.Server;
using Examer.Server.Data;
using Examer.Server.Models;
using Microsoft.EntityFrameworkCore; 




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.LogTo(Console.WriteLine);
    options.UseSqlServer(connectionString);
}
);
builder.Services.AddScoped<IBaseRepository<Project>, BaseRepository<Project>>();
builder.Services.AddScoped<IBaseRepository<Problem>, BaseRepository<Problem>>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        // builder.AllowAnyOrigin();
        builder.WithOrigins("http://localhost:3000");
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();


app.UseAuthorization();

app.UseCors("MyPolicy");

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
