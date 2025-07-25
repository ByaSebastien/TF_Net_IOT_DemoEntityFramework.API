using Microsoft.EntityFrameworkCore;
using TF_Net_IOT_DemoEntityFramework.BLL.Services;
using TF_Net_IOT_DemoEntityFramework.DAL.Contexts;
using TF_Net_IOT_DemoEntityFramework.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContext,MyAppContext>(o => 
    o.UseSqlServer(builder.Configuration.GetConnectionString("Main")));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
