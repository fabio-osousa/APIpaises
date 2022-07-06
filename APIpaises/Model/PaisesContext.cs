using Microsoft.EntityFrameworkCore;

namespace APIpaises.Model
{
    public class PaisesContext : DbContext
    {
        public PaisesContext(DbContextOptions<PaisesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Paises> Paises{ get; set; }
    }
}
