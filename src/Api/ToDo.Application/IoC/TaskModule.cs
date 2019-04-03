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
            // some fake initial data
            var taskDatabase = new InMemoryRepository<Task>();

            var task1 = new Task("Go to shopping", "Buy eggs, fruits, milk, chocolate, some vegetables and things to clean the windows");
            task1.ChangeStatus(TaskStatus.Finished);
            var task2 = new Task("Read Innovator Dilemma book", "link to amazon sdsdsdsdsdsdsdsdsdsdsdsdsd");
            task2.ChangeStatus(TaskStatus.InProgress);
            var task3 = new Task("Very important task", "orem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ");
            task3.ChangeStatus(TaskStatus.InProgress);
            var task4 = new Task("task4");
            task4.ChangeStatus(TaskStatus.Finished);

            taskDatabase.Save(new Task("Some other task", "ae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptate"));
            taskDatabase.Save(new Task("task6"));
            taskDatabase.Save(task1);
            taskDatabase.Save(task2);
            taskDatabase.Save(task3);
            taskDatabase.Save(task4);

            return taskDatabase;
        }
    }
}
