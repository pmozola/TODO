using System;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;
using MediatR;
using ToDo.Domain;

namespace ToDo.Application.CommandHandlers
{
    public class DeleteTaskCommandHandler : AsyncRequestHandler<DeleteTaskCommand>
    {
        private IRepository<Domain.TaskAggregate.Task> repository;

        public DeleteTaskCommandHandler(IRepository<Domain.TaskAggregate.Task> repository)
        {
            this.repository = repository;
        }

        protected override async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await this.repository.Delete(request.Id);
        }
    }

    public class DeleteTaskCommand : IRequest
    {
        public DeleteTaskCommand(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }

    public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskCommandValidator()
        {
            this.RuleFor(x => x.Id)
                .NotEqual(Guid.NewGuid())
                .WithMessage("Task Id is not valid.");
        }
    }
}