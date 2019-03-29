using System;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;
using MediatR;
using ToDo.Domain;
using Task = ToDo.Domain.TaskAggregate.Task;

namespace ToDo.Application.CommandHandlers
{
    public class CreateNewTaskCommandHandler : IRequestHandler<CreateNewTaskCommand, Guid>
    {
        private readonly IRepository<Task> repository;

        public CreateNewTaskCommandHandler(IRepository<Task> repository)
        {
            this.repository = repository;
        }

        public async Task<Guid> Handle(CreateNewTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Task(request.Title, request.Description);

            await this.repository.Save(task);

            return task.Id;
        }
    }

    public class CreateNewTaskCommand : IRequest<Guid>
    {
        public CreateNewTaskCommand(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }

        public string Title { get; }

        public string Description { get; }
    }

    public class CreateNewTaskCommandValidator : AbstractValidator<CreateNewTaskCommand>
    {
        public CreateNewTaskCommandValidator()
        {
            this.RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Task title should be provided");
        }
    }
}