using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Behaviors;
using ToDo.Domain;
using ToDo.Infrastructure.InMemoryDatabase;

namespace ToDo.Application.IoC
{
    public static class TaskModule
    {
        public static void RegisterTaskModule(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            services.AddSingleton(typeof(IRepository<>), typeof(InMemoryRepository<>));
        }
    }
}
