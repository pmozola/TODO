using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.BaseObject;

namespace ToDo.Domain
{
    public interface IReadOnlyRepository<T>
    where T : AggregateRoot
    {
        Task<T> Get(Guid id);

        Task<T[]> GetAll();
    }
}
