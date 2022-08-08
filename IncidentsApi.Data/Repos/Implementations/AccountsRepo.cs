using IncidentsApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Implementations;

public class AccountsRepo : Abstractions.IAccountsRepo
{

    private readonly ApplicationDbContext _context;
    public AccountsRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public ValueTask<EntityEntry<Account>> AddAsync(Account account) => _context.Accounts.AddAsync(account);

    public async ValueTask<bool> ExistsAsync(Account account) => (await GetByNameAsync(account.Name)) is not null;
    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

    public void Update(Account account) => _context.Accounts.Update(account);

    private Task<Account> GetByNameAsync(string accountName) => _context.Accounts.AsNoTracking().FirstOrDefaultAsync(account => account.Name == accountName);

}
