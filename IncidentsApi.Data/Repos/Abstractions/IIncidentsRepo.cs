using Microsoft.EntityFrameworkCore.ChangeTracking;
using IncidentsApi.Data.Models;


namespace IncidentsApi.Data.Repos.Abstractions;

public interface IIncidentsRepo
{
    ValueTask<EntityEntry<Incident>> AddAsync(Incident incident);
    Task<int> SaveChangesAsync();
}
