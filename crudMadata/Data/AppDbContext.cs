using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using crudMadata.Models;

namespace crudMadata.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ContactoModel> Contactos { get; set; }
    }

}
