using API.Extensions;
using API.MiddleWare;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationService(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/error/{0}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope(); 
//This will start the scope of services and lifetimes in dependancy injection
var services = scope.ServiceProvider;
/*This is responsible for the services provided by dependency injection. Service provider will resolve the services*/                                  
var context = services.GetRequiredService<StoreDbContext>(); 
/*This line retives instance of storeDbContext and getrequiredservices will be getrequiredservice method will make sure service is resolved, 
.if it is not resolved then exception is thrown*/
var logger = services.GetRequiredService<ILogger<Program>>();
 /*this service will institate Ilogger service and from program class and log error infomation*/                                                               
try
{
    await context.Database.MigrateAsync();
    //asynchroulsy update database and create database if don't exisit
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    
    logger.LogError(ex,"An error occured during Migration");
}

app.Run();
