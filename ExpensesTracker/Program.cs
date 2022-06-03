using Microsoft.EntityFrameworkCore;
using ExpensesTracker.BussinessLogic;
using ExpensesTracker.BussinessLogic.Abstract;
using ExpensesTracker.BussinessLogic.Implementation;
using ExpensesTracker.Data;
using ExpensesTracker.Data.Repository;
using ExpensesTracker.Data.Repository.IRepository;
using ExpensesTracker.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>
               (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IMessageParserService, MessageParserService>();
builder.Services.AddScoped<IOperationDispatch, OperationDispatch>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardNumberParser, CardNumberParser>();
builder.Services.AddScoped<ISumHandler, SumHandler>();
builder.Services.AddScoped<IDateTimeHandler, DateTimeHandler>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IAvailiableSumHandler, AvailiableSumHandler>();
builder.Services.AddScoped<IBankingAccountService, BankingAccountService>();
builder.Services.AddScoped<IBankingAccountRepository, BankingAccountRepository>();
builder.Services.AddScoped<IAvailiableSumHandler, AvailiableSumHandler>();
builder.Services.AddScoped<IOperationTypeHandler, OperationTypeHandler>();
builder.Services.AddScoped<IPaymentCancelPaymentService, PaymentCancelPaymentService>();
builder.Services.AddScoped<IBaseOperationService, BaseOperationService>();
builder.Services.AddTransient<IBaseMessageCreator<PaymentCancelPaymentMessage>, PaymentMessageCreator>();
builder.Services.AddTransient<IBaseMessageCreator<RefusalMessage>, RefusalMessageCreator>();


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
