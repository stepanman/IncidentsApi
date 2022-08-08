using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentsApi.Data.Models;

namespace IncidentsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; } 
        public DbSet<Account> Accounts { get; set; } 
        public DbSet<Contact> Contacts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
