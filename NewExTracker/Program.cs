using Microsoft.EntityFrameworkCore;
using NewExTracker.BussinessLogic;
using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.BussinessLogic.Implementation;
using NewExTracker.Data;
using NewExTracker.Data.Repository;
using NewExTracker.Data.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>
               (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IMessageParserService, MessageParserService>();
builder.Services.AddScoped<IOperationDispatch, OperationDispatch>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ISumHandler, SumHandler>();
builder.Services.AddScoped<IDateTimeHandler, DateTimeHandler>();
builder.Services.AddScoped<ICardRepository, CardRepository>();

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
