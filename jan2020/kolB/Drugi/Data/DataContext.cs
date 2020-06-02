using Microsoft.EntityFrameworkCore;

namespace Drugi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Sastojak> Sastojak { get; set; }

        public DbSet<Recept> Recept { get; set; }
    }
}