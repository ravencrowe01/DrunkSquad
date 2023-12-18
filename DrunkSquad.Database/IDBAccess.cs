namespace DrunkSquad.Database {
    public interface IDBAccess<T> where T : class {
        Task AddAsync (T entity);

        Task<T> FindAsync (int id);

        Task<bool> UpdateAsync (T Entity, int id);

        Task<bool> DeleteAsync (int id);
    }
}
