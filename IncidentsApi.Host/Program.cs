using Microsoft.EntityFrameworkCore;

using IncidentsApi.Data;
using IncidentsApi.Data.Repos.Interfaces;
using IncidentsApi.Data.Repos.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IIncidentsRepo, IncidentsRepo>();
builder.Services.AddScoped<IAccountsRepo, AccountsRepo>();
builder.Services.AddScoped<IContactsRepo, ContactsRepo>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.Run();