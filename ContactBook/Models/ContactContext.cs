using System;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
