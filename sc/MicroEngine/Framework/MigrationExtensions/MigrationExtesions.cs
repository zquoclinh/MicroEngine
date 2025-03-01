using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using FluentMigrator.Builders.Alter.Table;
using FluentMigrator.Builders.Create;
using FluentMigrator.Builders.Create.Table;
using FluentMigrator.Expressions;
using FluentMigrator.Model;
using MicroEngine.Framework.Commons;
using MicroEngine.Framework.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroEngine.Framework.MigrationExtensions
{
    public static class FluentMigratorExtensions
    {
        private const int DATE_TIME_PRECISION = 6;

        private static Dictionary<
            Type,
            Action<ICreateTableColumnAsTypeSyntax>
        > TypeMapping { get; } =
            new Dictionary<Type, Action<ICreateTableColumnAsTypeSyntax>>
            {
                [typeof(int)] = delegate(ICreateTableColumnAsTypeSyntax c)
                {
                    c.AsInt32();
                },
                [typeof(long)] = delegate(ICreateTableColumnAsTypeSyntax c)
                {
                    c.AsInt64();
                },
                [typeof(string)] = delegate(ICreateTableColumnAsTypeSyntax c)
                {
                    c.AsString(int.MaxValue).Nullable();
                },
                [typeof(bool)] = delegate(ICreateTableColumnAsTypeSyntax c)
                {
                    c.AsBoolean();
                },
                [typeof(decimal)] = delegate(ICreateTableColumnAsTypeSyntax c)
                {
                    c.AsDecimal(18, 8);
                },
                [typeof(DateTime)] = delegate(ICreateTableColumnAsTypeSyntax c)
                {
                    c.AsNeptuneDateTime2();
                },
                [typeof(byte[])] = delegate(ICreateTableColumnAsTypeSyntax c)
                {
                    c.AsBinary(int.MaxValue);
                },
                [typeof(Guid)] = delegate(ICreateTableColumnAsTypeSyntax c)
                {
                    c.AsGuid();
                },
            };

        private static void DefineByOwnType(
            string columnName,
            Type propType,
            CreateTableExpressionBuilder create,
            bool canBeNullable = false
        )
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException("The column name cannot be empty");
            }

            if (
                propType == typeof(string)
                || propType
                    .FindInterfaces(
                        (Type t, object? o) =>
                            t.FullName?.Equals(
                                o!.ToString(),
                                StringComparison.InvariantCultureIgnoreCase
                            ) ?? false,
                        "System.Collections.IEnumerable"
                    )
                    .Length != 0
            )
            {
                canBeNullable = true;
            }

            ICreateTableColumnAsTypeSyntax obj = create.WithColumn(columnName);
            TypeMapping[propType](obj);
            if (propType == typeof(DateTime))
            {
                create.CurrentColumn.Precision = 6;
            }

            if (canBeNullable)
            {
                create.Nullable();
            }
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax AsNeptuneDateTime2(
            this ICreateTableColumnAsTypeSyntax syntax
        )
        {
            DataConfig dataConfig = DataSettingsManager.LoadSettings();
            DataProviderType dataProvider = dataConfig.DataProvider;
            if (1 == 0) { }

            ICreateTableColumnOptionOrWithColumnSyntax result;
            switch (dataProvider)
            {
                case DataProviderType.MySql:
                {
                    DefaultInterpolatedStringHandler defaultInterpolatedStringHandler =
                        new DefaultInterpolatedStringHandler(10, 1);
                    defaultInterpolatedStringHandler.AppendLiteral("datetime(");
                    defaultInterpolatedStringHandler.AppendFormatted(6);
                    defaultInterpolatedStringHandler.AppendLiteral(")");
                    result = syntax.AsCustom(defaultInterpolatedStringHandler.ToStringAndClear());
                    break;
                }
                case DataProviderType.SqlServer:
                {
                    DefaultInterpolatedStringHandler defaultInterpolatedStringHandler =
                        new DefaultInterpolatedStringHandler(11, 1);
                    defaultInterpolatedStringHandler.AppendLiteral("datetime2(");
                    defaultInterpolatedStringHandler.AppendFormatted(6);
                    defaultInterpolatedStringHandler.AppendLiteral(")");
                    result = syntax.AsCustom(defaultInterpolatedStringHandler.ToStringAndClear());
                    break;
                }
                default:
                    result = syntax.AsDateTime2();
                    break;
            }

            if (1 == 0) { }

            return result;
        }

        public static ICreateTableColumnOptionOrForeignKeyCascadeOrWithColumnSyntax ForeignKey<TPrimary>(
            this ICreateTableColumnOptionOrWithColumnSyntax column,
            string primaryTableName = null,
            string primaryColumnName = null,
            Rule onDelete = Rule.Cascade
        )
            where TPrimary : BaseEntity
        {
            if (string.IsNullOrEmpty(primaryTableName))
            {
                primaryTableName = NameCompatibilityManager.GetTableName(typeof(TPrimary));
            }

            if (string.IsNullOrEmpty(primaryColumnName))
            {
                primaryColumnName = "Id";
            }

            return column
                .Indexed()
                .ForeignKey(primaryTableName, primaryColumnName)
                .OnDelete(onDelete);
        }

        public static IAlterTableColumnOptionOrAddColumnOrAlterColumnOrForeignKeyCascadeSyntax ForeignKey<TPrimary>(
            this IAlterTableColumnOptionOrAddColumnOrAlterColumnSyntax column,
            string primaryTableName = null,
            string primaryColumnName = null,
            Rule onDelete = Rule.Cascade
        )
            where TPrimary : BaseEntity
        {
            if (string.IsNullOrEmpty(primaryTableName))
            {
                primaryTableName = NameCompatibilityManager.GetTableName(typeof(TPrimary));
            }

            if (string.IsNullOrEmpty(primaryColumnName))
            {
                primaryColumnName = "Id";
            }

            return column
                .Indexed()
                .ForeignKey(primaryTableName, primaryColumnName)
                .OnDelete(onDelete);
        }

        public static void TableFor<TEntity>(this ICreateExpressionRoot expressionRoot)
            where TEntity : BaseEntity
        {
            Type typeFromHandle = typeof(TEntity);
            CreateTableExpressionBuilder builder =
                expressionRoot.Table(NameCompatibilityManager.GetTableName(typeFromHandle))
                as CreateTableExpressionBuilder;
            builder.RetrieveTableExpressions(typeFromHandle);
        }

        public static void RetrieveTableExpressions(
            this CreateTableExpressionBuilder builder,
            Type type
        )
        {
            Type type2 = Singleton<ITypeFinder>
                .Instance.FindClassesOfType(typeof(IEntityBuilder))
                .FirstOrDefault(
                    (Type t) => t.BaseType?.GetGenericArguments().Contains(type) ?? false
                );
            if (type2 != null)
            {
                (EngineContext.Current.ResolveUnregistered(type2) as IEntityBuilder)?.MapEntity(
                    builder
                );
            }

            CreateTableExpression expression = builder.Expression;
            if (!expression.Columns.Any((ColumnDefinition c) => c.IsPrimaryKey))
            {
                ColumnDefinition columnDefinition = new ColumnDefinition
                {
                    Name = "Id",
                    Type = DbType.Int32,
                    IsIdentity = true,
                    TableName = NameCompatibilityManager.GetTableName(type),
                    ModificationType = ColumnModificationType.Create,
                    IsPrimaryKey = true,
                };
                expression.Columns.Insert(0, columnDefinition);
                builder.CurrentColumn = columnDefinition;
            }

            IEnumerable<PropertyInfo> enumerable =
                from pi in type.GetProperties(
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty
                )
                where
                    pi.DeclaringType != typeof(BaseEntity)
                    && pi.CanWrite
                    && !pi.HasAttribute<NotMappedAttribute>()
                    && !pi.HasAttribute<NotColumnAttribute>()
                    && !expression.Columns.Any(
                        (ColumnDefinition x) =>
                            x.Name.Equals(
                                NameCompatibilityManager.GetColumnName(type, pi.Name),
                                StringComparison.OrdinalIgnoreCase
                            )
                    )
                    && TypeMapping.ContainsKey(pi.PropertyType.GetTypeToMap().propType)
                select pi;
            foreach (PropertyInfo item in enumerable)
            {
                string columnName = NameCompatibilityManager.GetColumnName(type, item.Name);
                var (propType, canBeNullable) = item.PropertyType.GetTypeToMap();
                DefineByOwnType(columnName, propType, builder, canBeNullable);
            }
        }

        public static (Type propType, bool canBeNullable) GetTypeToMap(this Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            if ((object)underlyingType != null)
            {
                return (underlyingType, true);
            }

            return (type, false);
        }
    }
}
