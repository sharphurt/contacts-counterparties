using ContactsCounterparties.Database;
using ContactsCounterparties.Dto;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Exception;
using ContactsCounterparties.Model;
using ContactsCounterparties.Repository;
using ContactsCounterparties.Repository.Implementation;
using ContactsCounterparties.Service;
using ContactsCounterparties.Service.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ICounterpartyRepository, CounterpartyRepository>();
builder.Services.AddScoped<IContactSqlService, ContactSqlService>();
builder.Services.AddScoped<ICounterpartySqlService, CounterpartySqlService>();
builder.Services.AddAutoMapper(expression =>
{
    expression.CreateMap<Contact, ContactInformationDto>();
    expression.CreateMap<Counterparty, CounterpartyInformationDto>();
});

builder.Services.AddMvc();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

var app = builder.Build();
app.UseExceptionHandler(exceptionHandlerApp => { exceptionHandlerApp.Run(GlobalExceptionHandler.HandleException); });

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();