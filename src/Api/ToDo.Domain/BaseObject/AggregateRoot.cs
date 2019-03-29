using System;

namespace ToDo.Domain.BaseObject
{
    public class AggregateRoot
    {
        public Guid Id { get; protected set; }
    }
}