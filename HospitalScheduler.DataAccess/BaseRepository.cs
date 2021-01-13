using HospitalScheduler.Common;
using System.Linq;

namespace HospitalScheduler.DataAccess
{   // sa imi explice Mandel asta bine
    public class BaseRepository<T>
        where T : class, IEntity
    {
        private readonly HospitalSchedulerContext Context;

        public BaseRepository(HospitalSchedulerContext context)
        {
            this.Context = context;
        }

        public IQueryable<T> Get()
        {
            return Context.Set<T>().AsQueryable();
        }

        public T Insert(T entity)
        {
            Context.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            Context.Set<T>().Update(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}
