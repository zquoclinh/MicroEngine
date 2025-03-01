using Microsoft.EntityFrameworkCore;

namespace MicroEngine.Framework.MigrationExtensions
{
    public interface IEntitySeed
    {
        void SeedData(ModelBuilder modelBuilder);
    }
}
