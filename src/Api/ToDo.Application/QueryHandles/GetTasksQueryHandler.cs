using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using ToDo.Domain;
using Task = ToDo.Domain.TaskAggregate.Task;

namespace ToDo.Application.QueryHandles
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IList<TaskViewModel>>
    {
        private readonly IReadOnlyRepository<Task> repository;

        public GetTasksQueryHandler(IReadOnlyRepository<Task> repository)
        {
            this.repository = repository;
        }

        public async Task<IList<TaskViewModel>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await this.repository.GetAll();

            return tasks.Select(x => new TaskViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                StatusId = (int)x.Status,
                Title = x.Title
            }).ToList();
        }
    }

    public class GetTasksQuery : IRequest<IList<TaskViewModel>>
    {
    }

    public class TaskViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }
    }
}
