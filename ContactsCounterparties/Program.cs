using ContactsCounterparties.Database;
using ContactsCounterparties.Model;
using ContactsCounterparties.Repository;
using ContactsCounterparties.Repository.Implementation;
using ContactsCounterparties.Service;
using ContactsCounterparties.Service.Implementation;
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

builder.Services.AddMvc();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();