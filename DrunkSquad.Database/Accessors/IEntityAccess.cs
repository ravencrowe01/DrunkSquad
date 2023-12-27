namespace DrunkSquad.Database.Accessors {
    public interface IEntityAccess<T> where T : class {
        IEnumerable<T> Set { get; }

        void Add (T entity);
        T FindByID (int id);
        void Remove (T entity);
        void Update (T entity);
    }
}