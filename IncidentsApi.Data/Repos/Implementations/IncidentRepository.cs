using IncidentsApi.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Implementations;

public class IncidentRepository : Interfaces.IIncidentRepository
{
    private readonly ApplicationDbContext _context;
    public IncidentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(Incident incident) => _context.Incidents.Add(incident);

    public ValueTask<EntityEntry<Incident>> CreateAsync(Incident incident) => _context.Incidents.AddAsync(incident);

    public void SaveChanges() => _context.SaveChanges();

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}
