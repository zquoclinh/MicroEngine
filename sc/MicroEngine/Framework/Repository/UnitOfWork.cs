namespace MicroEngine.Framework.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<Type, object> _repositories = new();
    private readonly MyDbContext _context;

    public UnitOfWork(IServiceProvider serviceProvider, MyDbContext context)
    {
        _serviceProvider = serviceProvider;
        _context = context;
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = _serviceProvider.GetRequiredService<IRepository<TEntity>>();
        }
        return (IRepository<TEntity>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
