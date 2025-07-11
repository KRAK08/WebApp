using Microsoft.EntityFrameworkCore;
using WebApp.API.Data;
using WebApp.API.Repositories.Implementations;
using WebApp.API.Repositories.Interfaces;
using WebApp.API.UnitsOfWork.Implementations;
using WebApp.API.UnitsOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(r => r.LowercaseUrls = true);
builder.Services.AddDbContext<DataContext>(d => d.UseSqlServer(builder.Configuration.GetConnectionString("dbConn")));

builder.Services.AddScoped(typeof(IGeneric<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped<IProductUnitOfWork, ProductUnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.MapControllers();

app.Run();