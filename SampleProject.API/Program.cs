using Microsoft.EntityFrameworkCore;
using SampleProject.Application.Customers.DomainServices;
using SampleProject.Application.Customers.RegisterCustomer;
using SampleProject.Domain.Customers;
using SampleProject.Domain.SeedWork;
using SampleProject.Infrastructure.Database;
using SampleProject.Infrastructure.Domain.Customers;
using System.Reflection;
using SampleProject.Contract.Customers;
using SampleProject.Contract.Queries;
using SampleProject.Application.Configuration.Validation;
using MediatR;
using static System.Net.Mime.MediaTypeNames;
using Autofac.Core;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using SampleProject.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<OrdersContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICommandCustomerRepository, CommandCustomerRepository>();
builder.Services.AddScoped<IQueryCustomerRepository, QueryCustomerRepository>();
builder.Services.AddScoped<ICustomerUniquenessChecker, CustomerUniquenessChecker>();









builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

});
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OrdersContext>();
    db.Database.Migrate();
}



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