using MicroEngine.Data.Entities;
using MicroEngine.Framework.Entity;
using MicroEngine.Framework.Migration;
using Microsoft.EntityFrameworkCore;

namespace MicroEngine.Migrations.DataMigrations
{
    public class DataSettingMigration2 : IEntitySeed
    {
        public void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Setting>()
                .HasData(
                    new Setting
                    {
                        Name = "WebApiSetting.Audience",
                        Value = "JWTServicePostmanClient",
                    },
                    new Setting
                    {
                        Name = "WebApiSetting.Issuer",
                        Value = "JWTAuthenticationServer",
                    },
                    new Setting { Name = "WebApiSetting.Subject", Value = "JWTServiceAccessToken" }
                );
        }
    }
}
