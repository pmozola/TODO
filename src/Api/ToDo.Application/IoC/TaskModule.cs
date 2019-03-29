using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Behaviors;

namespace ToDo.Application.IoC
{
    public static class TaskModule
    {
        public static void RegisterTaskModule(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
        }
    }
}
