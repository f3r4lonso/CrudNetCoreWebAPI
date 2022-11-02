using CRUDWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebAPI.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
