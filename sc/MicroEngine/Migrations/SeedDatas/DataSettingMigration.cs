using MicroEngine.Data.Entities;
using MicroEngine.Framework.Entity;
using MicroEngine.Framework.MigrationExtensions;
using Microsoft.EntityFrameworkCore;

namespace MicroEngine.Migrations.DataMigrations
{
    public class DataSettingMigration : IEntitySeed
    {
        public void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Setting>()
                .HasData(
                    new Setting
                    {
                        Name = "WebApiSetting.SecretKey",
                        Value = "lNMJ8FzDjL15jalPwAXcR3RV46EQsO5N",
                    }
                );
        }
    }
}
