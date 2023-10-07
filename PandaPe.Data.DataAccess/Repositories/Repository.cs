using PandaPe.Data.Application.Contracts.Persistence.Repositories;
using PandaPe.Data.Models.Base;

namespace PandaPe.Data.DataAccess.Repositories
{
    public class Repository<T, TId> : RepositoryWithTypedId<T, TId>, IRepository<T, TId>
        where T : class, IEntityWithTypedId<TId>
    {
        public Repository(PandaPeDbContext context) : base(context)
        {

        }
    }
}
