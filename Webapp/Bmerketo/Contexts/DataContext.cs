using Bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdressEntity> Adresses { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
