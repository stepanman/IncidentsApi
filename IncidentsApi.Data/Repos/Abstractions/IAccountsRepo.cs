using Microsoft.EntityFrameworkCore.ChangeTracking;
using IncidentsApi.Data.Models;

namespace IncidentsApi.Data.Repos.Abstractions;

public interface IAccountsRepo
{
    ValueTask<EntityEntry<Account>> AddAsync(Account account);
    ValueTask<bool> ExistsAsync(Account account);
    public void Update(Account account);
    Task<int> SaveChangesAsync();

}
