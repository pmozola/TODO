using System;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;
using MediatR;
using ToDo.Domain;
using TaskStatus = ToDo.Domain.TaskAggregate.TaskStatus;

namespace ToDo.Application.CommandHandlers
{
    public class ChangeTaskStatusCommandHandler : AsyncRequestHandler<ChangeTaskStatusCommand>
    {
        private IRepository<Domain.TaskAggregate.Task> repository;

        public ChangeTaskStatusCommandHandler(IRepository<Domain.TaskAggregate.Task> repository)
        {
            this.repository = repository;
        }

        protected override async Task Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await this.repository.Get(request.TaskId);

            task.ChangeStatus((TaskStatus)request.Status);

            await this.repository.Update(task);
        }
    }

    public class ChangeTaskStatusCommand : IRequest
    {
        public ChangeTaskStatusCommand(Guid taskId, int status)
        {
            this.TaskId = taskId;
            this.Status = status;
        }

        public Guid TaskId { get; }

        public int Status { get; }
    }

    public class ChangeTaskStatusCommandValidator : AbstractValidator<ChangeTaskStatusCommand>
    {
        public ChangeTaskStatusCommandValidator()
        {
            this.RuleFor(x => x.TaskId)
                .NotNull()
                .NotEqual(Guid.Empty)
                .WithMessage("Task Id is not valid.");

            this.RuleFor(x => x.Status)
                .Must(x => Enum.IsDefined(typeof(TaskStatus), x))
                .WithMessage("Its not a valid task status");
        }
    }
}
