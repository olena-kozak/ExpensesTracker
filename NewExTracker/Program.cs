using Microsoft.EntityFrameworkCore;
using NewExTracker.BussinessLogic;
using NewExTracker.BussinessLogic.Abstract;
using NewExTracker.BussinessLogic.Implementation;
using NewExTracker.Data;
using NewExTracker.Data.Repository;
using NewExTracker.Data.Repository.IRepository;
using NewExTracker.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>
               (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IMessageParserService, MessageParserService>();
builder.Services.AddSingleton<IOperationDispatch, OperationDispatch>();
builder.Services.AddSingleton<ICardService, CardService>();
builder.Services.AddSingleton<ISumHandler, SumHandler>();
builder.Services.AddSingleton<IDateTimeHandler, DateTimeHandler>();
builder.Services.AddSingleton<IPlaceService, PlaceService>();
builder.Services.AddSingleton<IPlaceRepository, PlaceRepository>();
builder.Services.AddSingleton<ICardRepository, CardRepository>();
builder.Services.AddSingleton<IAvailiableSumHandler, AvailiableSumHandler>();
builder.Services.AddSingleton<IBankingAccountService, BankingAccountService>();
builder.Services.AddSingleton<IBankingAccountRepository, BankingAccountRepository>();


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
