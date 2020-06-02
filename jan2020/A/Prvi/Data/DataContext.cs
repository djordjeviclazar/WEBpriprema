using Microsoft.EntityFrameworkCore;
using Prvi.Models;

namespace Prvi.Data
{
    public class DataContext: DbContext
    {
        
        public DbSet<Fabrika> Fabrike { get; set;}

        public DbSet<Silos> Silosi { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
    }
}