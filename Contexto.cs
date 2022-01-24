using Microsoft.EntityFrameworkCore;


namespace Tarea_2
{
    public class Contexto : DbContext
    {
        public DbSet<Roles> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Roles.db");
        }
    }
}