using System;

namespace ToDo.Domain.BaseObject
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {
        }
    }
}
