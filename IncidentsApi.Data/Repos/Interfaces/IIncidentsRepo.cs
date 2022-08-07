using Microsoft.EntityFrameworkCore.ChangeTracking;
using IncidentsApi.Data.Models;


namespace IncidentsApi.Data.Repos.Interfaces;

public interface IIncidentsRepo
{
    ValueTask<EntityEntry<Incident>> AddAsync(Incident incident);
    Task<int> SaveChangesAsync();
}
