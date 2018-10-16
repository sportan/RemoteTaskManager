using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Svc.EntityFramework.Repositories
{
    public abstract class SvcRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SvcDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SvcRepositoryBase(IDbContextProvider<SvcDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }

    public abstract class SvcRepositoryBase<TEntity> : SvcRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SvcRepositoryBase(IDbContextProvider<SvcDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
