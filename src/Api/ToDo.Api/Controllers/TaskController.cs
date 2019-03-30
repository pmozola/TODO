using System;
using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using ToDo.Application.CommandHandlers;
using ToDo.Application.QueryHandles;

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator mediator;

        public TaskController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await this.mediator.Send(new GetTasksQuery());

            if (result.Any())
            {
                return this.Ok(result);
            }

            return this.NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateNewTaskCommand command)
        {
            return this.Ok(await this.mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return this.Ok(await this.mediator.Send(new DeleteTaskCommand(id)));
        }
    }
}
