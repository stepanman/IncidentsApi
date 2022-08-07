using Microsoft.EntityFrameworkCore.ChangeTracking;
using IncidentsApi.Data.Models;

namespace IncidentsApi.Data.Repos.Interfaces;

public interface IAccountsRepo
{
    ValueTask<EntityEntry<Account>> AddAsync(Account account);
    public ValueTask<Account?> FindAsync(string accountName);
    Task<int> SaveChangesAsync();

}
