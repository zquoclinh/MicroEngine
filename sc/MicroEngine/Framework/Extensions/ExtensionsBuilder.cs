using System.Reflection;
using MicroEngine.Framework.MigrationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroEngine.Framework.Extensions
{
    public static class ExtensionsBuilder
    {
        public static PropertyBuilder<string> AsString(
            this PropertyBuilder<string> propertyBuilder,
            int maxLength
        )
        {
            propertyBuilder.HasColumnType($"nvarchar({maxLength})");
            return propertyBuilder;
        }
    }

    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ApplyAllConfigurationsFromCurrentAssembly(
            this ModelBuilder modelBuilder
        )
        {
            var typesToRegister = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type =>
                    type.GetInterfaces()
                        .Any(interfaceType =>
                            interfaceType.IsGenericType
                            && interfaceType.GetGenericTypeDefinition()
                                == typeof(IEntityTypeConfiguration<>)
                        )
                )
                .ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            return modelBuilder;
        }

        public static ModelBuilder ApplySeedDataFromCurrentAssembly(this ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(IEntitySeed).IsAssignableFrom(type) && !type.IsInterface);

            foreach (var type in typesToRegister)
            {
                var seedInstance = (IEntitySeed)Activator.CreateInstance(type);
                seedInstance.SeedData(modelBuilder);
            }

            return modelBuilder;
        }
    }
}
