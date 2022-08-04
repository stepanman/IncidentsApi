using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Interfaces;

public interface IContactRepository 
{ 
    void Create(Models.Contact contact);
    ValueTask<EntityEntry<Models.Contact>> CreateAsync(Models.Contact contact);

    void Update(Models.Contact contact);

    void SaveChanges();
    Task<int> SaveChangesAsync();
}
