using IncidentsApi.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Implementations;

public class IncidentsRepo : Abstractions.IIncidentsRepo
{
    private readonly ApplicationDbContext _context;
    public IncidentsRepo(ApplicationDbContext context)
    {
        _context = context;
    }
    public ValueTask<EntityEntry<Incident>> AddAsync(Incident incident) => _context.Incidents.AddAsync(incident);
    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}
