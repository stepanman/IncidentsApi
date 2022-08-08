using Microsoft.EntityFrameworkCore;

using IncidentsApi.Data;
using IncidentsApi.Data.Repos.Abstractions;
using IncidentsApi.Data.Repos.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IContactsRepo, ContactsRepo>();
builder.Services.AddScoped<IAccountsRepo, AccountsRepo>();
builder.Services.AddScoped<IIncidentsRepo, IncidentsRepo>();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseRouting();

app.UseHttpLogging();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();