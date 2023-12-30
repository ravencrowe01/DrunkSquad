using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database.Accessors {
    public class EntityAccess<T> (DbSet<T> set, DbContext context) : IEntityAccess<T> where T : class {
        protected DbSet<T> _set = set;
        protected DbContext _context = context;

        public DbSet<T> Set => _set;

        public T FindByID (int id) => _set.Find (id);

        public void Update (T entity) => _set.Update (entity);

        public void Add (T entity) {
            _set.Add (entity);
            _context.SaveChanges ();
        }

        public void AddRange (IEnumerable<T> entites) {
            foreach (var entity in entites) {
                _set.Add (entity);
            }

            _context.SaveChanges ();
        }

        public void Remove (T entity) {
            _set.Remove (entity);
            _context.SaveChanges ();
        }
    }
}
