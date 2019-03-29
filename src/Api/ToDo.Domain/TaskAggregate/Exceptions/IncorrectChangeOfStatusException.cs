using ToDo.Domain.BaseObject;

namespace ToDo.Domain.TaskAggregate.Exceptions
{
    public class IncorrectChangeOfStatusException : DomainException
    {
        public IncorrectChangeOfStatusException(string message)
            : base(message)
        {
        }
    }
}
