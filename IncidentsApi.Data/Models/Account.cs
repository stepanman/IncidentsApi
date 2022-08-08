using System.ComponentModel.DataAnnotations;

namespace IncidentsApi.Data.Models;

public class Account
{
    [Key, MinLength(1)]
    public string Name { get; set; }
    public List<Contact> Contacts { get; set; } = new List<Contact>();
    public List<Incident> Incidents { get; set; } = new List<Incident>();
}