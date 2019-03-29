using System;
using System.Threading.Tasks;

using ToDo.Domain.BaseObject;

namespace ToDo.Domain
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        Task Save(T aggregate);

        Task<T> Get(Guid id);

        Task Update(T task);

        Task Delete(Guid requestId);
    }
}