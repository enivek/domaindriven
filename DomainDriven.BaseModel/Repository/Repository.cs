using DomainDriven.BaseModel.Model;
using System.Threading.Tasks;

namespace DomainDriven.BaseModel.Repository
{
    public abstract class Repository<TId, TAggregateRoot> where TAggregateRoot : AggregateRoot<TId> 
    {

        public abstract Task<TAggregateRoot> GetById(TId id);

        public abstract Task<bool> InsertOrUpdate(TAggregateRoot aggregateRoot);

        public abstract Task Delete(TId id);

    }
}
