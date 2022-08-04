using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Interfaces;

public interface IAccountRepository
{
    void Create(Models.Account account);
    ValueTask<EntityEntry<Models.Account>> CreateAsync(Models.Account account);

    bool Exists(string accountId);

    void SaveChanges();
    Task<int> SaveChangesAsync();

}
