using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToDo.Domain;
using ToDo.Domain.BaseObject;

namespace ToDo.Infrastructure.InMemoryDatabase
{
    public class InMemoryRepository<T> : IRepository<T>
        where T : AggregateRoot
    {

        private static readonly object SyncObject = new object();
        private readonly List<T> fakeDatabase;

        public InMemoryRepository()
        {
            this.fakeDatabase = new List<T>();
        }

        public Task Delete(Guid id)
        {
            lock (SyncObject)
            {
                this.fakeDatabase.Remove(this.fakeDatabase.Single(x => x.Id == id));
            }

            return Task.CompletedTask;
        }

        public Task<T> Get(Guid id)
        {
            lock (SyncObject)
            {
                return Task.FromResult(this.fakeDatabase.Single(x => x.Id == id));
            }
        }

        public Task Save(T aggregate)
        {
            lock (SyncObject)
            {
                this.fakeDatabase.Add(aggregate);
            }

            return Task.CompletedTask;
        }

        public Task Update(T aggregate)
        {
            lock (SyncObject)
            {
                this.fakeDatabase[this.fakeDatabase.FindIndex(x => x.Id == aggregate.Id)] = aggregate;
            }

            return Task.CompletedTask;
        }
    }
}
