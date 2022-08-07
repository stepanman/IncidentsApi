using IncidentsApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Implementations;

public class AccountsRepo : Interfaces.IAccountsRepo
{

    private readonly ApplicationDbContext _context;
    public AccountsRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public ValueTask<EntityEntry<Account>> AddAsync(Account account) => _context.Accounts.AddAsync(account);

    public ValueTask<Account?> FindAsync(string accountName) => _context.Accounts.FindAsync(accountName);

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}
