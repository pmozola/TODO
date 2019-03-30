using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Behaviors;
using ToDo.Domain;
using ToDo.Domain.TaskAggregate;
using ToDo.Infrastructure.InMemoryDatabase;

namespace ToDo.Application.IoC
{
    public static class TaskModule
    {
        public static void RegisterTaskModule(this IServiceCollection services)
        {
            services.AddMediatR();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));

            RegisterTaskDatabase(services);
        }

        private static void RegisterTaskDatabase(IServiceCollection services)
        {
            var taskDatabase = new InMemoryRepository<Task>();

            services.AddSingleton(typeof(IRepository<Task>), taskDatabase);
            services.AddSingleton(typeof(IReadOnlyRepository<Task>), taskDatabase);
        }
    }
}
