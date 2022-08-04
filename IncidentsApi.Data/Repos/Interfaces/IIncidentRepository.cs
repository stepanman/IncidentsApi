using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Interfaces;

public interface IIncidentRepository
{
    void Create(Models.Incident incident);
    ValueTask<EntityEntry<Models.Incident>> CreateAsync(Models.Incident incident);

    void SaveChanges();
    Task<int> SaveChangesAsync();
}
