using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Logging;
using Microsoft.EntityFrameworkCore;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

//Add DB connection Service
//here "DefaultSQLConnection" is the name of the ConnectionStrings under the appsetting
builder.Services.AddDbContext<ApplicationDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

// Add services to the container

////by adding this file enable logging & save into the file using Serilog
////rollingInterval : define the log file creation type:-
////rollingInterval:RollingInterval.Infinite ==> only one file
////rollingInterval:RollingInterval.Day ==> every day new file created
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//    .WriteTo.File("log/villalogs.txt",rollingInterval:RollingInterval.Day).CreateLogger();

////After setup Serilog, now add this serilog, it replace default logger to serilogger
////no need to change into the controller level, autoreflect in all places
//builder.Host.UseSerilog();

//xml support added to API
builder.Services.AddControllers(
        option =>
        {
            //option.ReturnHttpNotAcceptable= true; // default api return json format data
        }
    ).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); // support xml data


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogging,Logging>(); //Dependency Injection, service lifetime used here, custom logger class,
                                                   //In futre you want to change to new logger change only here, replace Logging to another class
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
