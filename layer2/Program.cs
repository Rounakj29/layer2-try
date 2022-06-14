
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using layer2.Data;
using layer2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<layer2Context>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("layer2Context") ?? throw new InvalidOperationException("Connection string 'layer2Context' not found.")));
builder.Services.AddScoped<UserService>();
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
