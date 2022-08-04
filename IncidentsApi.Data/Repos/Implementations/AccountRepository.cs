using IncidentsApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Implementations;

public class AccountRepository : Interfaces.IAccountRepository
{

    private readonly ApplicationDbContext _context;
    public AccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(Account account) => _context.Accounts.Add(account);

    public ValueTask<EntityEntry<Models.Account>> CreateAsync(Account account) => _context.Accounts.AddAsync(account);

    public bool Exists(string accountName) => _context.Accounts.AsNoTracking().Any(account => account.Name == accountName);

    public void SaveChanges() => _context.SaveChanges();

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}
