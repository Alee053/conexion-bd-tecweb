using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<conexion_bd_tecweb.Data.AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);


builder.Services.AddScoped<conexion_bd_tecweb.Services.IBookService, conexion_bd_tecweb.Services.BookService>();
builder.Services.AddScoped<conexion_bd_tecweb.Repositories.IBookRepository, conexion_bd_tecweb.Repositories.BookRepository>();

builder.Services.AddScoped<conexion_bd_tecweb.Services.ITicketService, conexion_bd_tecweb.Services.TicketService>();
builder.Services.AddScoped<conexion_bd_tecweb.Repositories.ITicketRepository, conexion_bd_tecweb.Repositories.TicketRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
