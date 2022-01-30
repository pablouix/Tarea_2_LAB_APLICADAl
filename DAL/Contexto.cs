using Microsoft.EntityFrameworkCore;
using Tarea_2.Entidades;

namespace Tarea_2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Roles>? Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\Roles.db");
        }
    }
}