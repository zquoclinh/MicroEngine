using MicroEngine.Framework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MicroEngine.Framework.Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
            modelBuilder.ApplySeedDataFromCurrentAssembly();
        }
    }
}
