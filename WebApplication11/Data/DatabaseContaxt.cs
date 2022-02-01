using Microsoft.EntityFrameworkCore;
using WebApplication11.Models;

namespace WebApplication11.Data
{
    public class DatabaseContaxt : DbContext
    {
        public DatabaseContaxt(DbContextOptions<DatabaseContaxt> options) :
            base(options)
        {

        }
        public DbSet<ProductModel> ProductModels { get; set; }
    }
}