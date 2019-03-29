using System;

using ToDo.Domain.BaseObject;
using ToDo.Domain.TaskAggregate.Exceptions;

namespace ToDo.Domain.TaskAggregate
{
    public class Task : AggregateRoot
    {
        public Task(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new TaskTitleDomainException("Task should have a title");
            }

            this.Id = Guid.NewGuid();
            this.Title = title;
        }

        public Task(string title, string description)
            : this(title)
        {
            this.Description = description;
        }

        public Guid Id { get; }

        public string Title { get; }

        public string Description { get; }

        public TaskStatus Status { get; private set; }

        public void ChangeStatus(TaskStatus newStatus)
        {
            if (this.Status > newStatus)
            {
                throw new IncorrectChangeOfStatusException(
                    $"Cannot change task status from {this.Status} to {newStatus}");
            }

            this.Status = newStatus;
        }
    }
}