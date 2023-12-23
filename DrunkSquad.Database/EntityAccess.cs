using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database {
    public class EntityAccess<T> (DbSet<T> set) : IEntityAccess<T> where T : class {
        protected DbSet<T> _set = set;

        public T FindByID (int id) => _set.Find (id);

        public void Update (T entity) => _set.Update (entity);

        public void Add (T entity) => _set.Add (entity);

        public void Remove (T entity) => _set.Remove (entity);
    }
}
