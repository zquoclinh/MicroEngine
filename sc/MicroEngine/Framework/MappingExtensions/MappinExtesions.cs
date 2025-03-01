using AutoMapper;
using MicroEngine.Framework.Commons;

namespace MicroEngine.Framework.MappinExtesions
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Init(MapperConfiguration config)
        {
            MapperConfiguration = config;
            Mapper = config.CreateMapper();
        }
    }

    public static class MappinExtesions
    {
        private static TDestination Map<TDestination>(this object source)
        {
            return AutoMapperConfiguration.Mapper.Map<TDestination>(source);
        }

        private static TDestination MapTo<TSource, TDestination>(
            this TSource source,
            TDestination destination
        )
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        public static TBaseJsonModel ToModel<TBaseJsonModel>(this object entity)
            where TBaseJsonModel : BaseModel
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return entity.Map<TBaseJsonModel>();
        }

        public static TEntity FromModel<TEntity>(this BaseModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            return model.Map<TEntity>();
        }

        public static TEntity ToEntity<TEntity>(this BaseEntity entity)
            where TEntity : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return entity.Map<TEntity>();
        }

        public static TEntity ToEntity<TEntity>(this BaseEntity entity, TEntity destination)
            where TEntity : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (destination == null)
            {
                throw new ArgumentNullException("destination");
            }

            return entity.MapTo(destination);
        }

        public static TEntity ToEntity<TEntity, TModel>(this TModel model, TEntity entity)
            where TEntity : BaseEntity
            where TModel : BaseModel
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return model.MapTo(entity);
        }

        public static TModel ToModel<TModel, TEntity>(this TEntity entity, TModel model)
            where TEntity : BaseEntity
            where TModel : BaseModel
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return entity.MapTo(model);
        }
    }
}
