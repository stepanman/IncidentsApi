using IncidentsApi.Data.Models;
using IncidentsApi.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Implementations;

public class ContactRepository : Interfaces.IContactRepository
{
    private readonly ApplicationDbContext _context;
    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(Models.Contact contact) => _context.Contacts.Add(contact);

    public ValueTask<EntityEntry<Models.Contact>> CreateAsync(Models.Contact contact) => _context.Contacts.AddAsync(contact);

    public void Update(Models.Contact contact) => _context.Contacts.Update(contact);

    public void SaveChanges() => _context.SaveChanges();

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

}
