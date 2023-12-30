using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database.Accessors {
    public interface IEntityAccess<T> where T : class {
        DbSet<T> Set { get; }

        void Add (T entity);
        void AddRange (IEnumerable<T> entites);
        T FindByID (int id);
        void Remove (T entity);
        void Update (T entity);
    }
}