using Microsoft.EntityFrameworkCore.ChangeTracking;
using IncidentsApi.Data.Models;

namespace IncidentsApi.Data.Repos.Interfaces;

public interface IContactsRepo 
{ 
    ValueTask<EntityEntry<Contact>> AddAsync(Contact contact);
    public ValueTask<Contact?> FindAsync(string contactEmail);
    Task SaveChangesAsync();
}
