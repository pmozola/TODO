using ToDo.Domain.BaseObject;

namespace ToDo.Domain.TaskAggregate.Exceptions
{
    public class TaskTitleDomainException : DomainException
    {
        public TaskTitleDomainException(string message)
            : base(message)
        {
        }
    }
}
