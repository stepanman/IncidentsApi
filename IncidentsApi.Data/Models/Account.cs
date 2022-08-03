using System.ComponentModel.DataAnnotations;

namespace IncidentsApi.Data.Models
{
    public class Account
    {
        [Key]
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Incident> Incidents { get; set; }
    }
}