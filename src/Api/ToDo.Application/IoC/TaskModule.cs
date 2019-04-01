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
            InMemoryRepository<Task> taskDatabase = PrepareFakeDatabase();

            services.AddSingleton(typeof(IRepository<Task>), taskDatabase);
            services.AddSingleton(typeof(IReadOnlyRepository<Task>), taskDatabase);
        }

        private static InMemoryRepository<Task> PrepareFakeDatabase()
        {
            var taskDatabase = new InMemoryRepository<Task>();

            var task1 = new Task("task1", "description1");
            task1.ChangeStatus(TaskStatus.Finished);
            var task2 = new Task("task2");
            task2.ChangeStatus(TaskStatus.InProgress);
            var task3 = new Task("task3", "description3");
            task3.ChangeStatus(TaskStatus.InProgress);
            var task4 = new Task("task4");
            task4.ChangeStatus(TaskStatus.Finished);

            taskDatabase.Save(new Task("task5"));
            taskDatabase.Save(new Task("task6"));
            taskDatabase.Save(task1);
            taskDatabase.Save(task2);
            taskDatabase.Save(task3);
            taskDatabase.Save(task4);

            return taskDatabase;
        }
    }
}
