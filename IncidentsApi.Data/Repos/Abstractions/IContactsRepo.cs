using Microsoft.EntityFrameworkCore.ChangeTracking;
using IncidentsApi.Data.Models;

namespace IncidentsApi.Data.Repos.Abstractions;

public interface IContactsRepo 
{ 
    ValueTask<EntityEntry<Contact>> AddAsync(Contact contact);
    ValueTask<bool> ExistsAsync(Contact contact);
    ValueTask<bool> IsLinkedAsync(Contact contact);
    void Update(Contact contact);
    Task SaveChangesAsync();
}
