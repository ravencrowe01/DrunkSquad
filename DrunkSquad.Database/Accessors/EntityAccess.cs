﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DrunkSquad.Database.Accessors {
    public class EntityAccess<T> (DbSet<T> set, DbContext context) : IEntityAccess<T> where T : class {
        protected DbSet<T> _set = set;
        protected DbContext _context = context;

        public DbSet<T> Set => _set;

        public T FindByID (int id) => _set.Find (id);

        public void Update (T entity) {
            _set.Update (entity);

            _context.SaveChanges ();
        }

        public void Add (T entity) {
            if (!_set.Contains (entity)) {
                _set.Add (entity);
                _context.SaveChanges ();
            }
        }

        public void AddRange (IEnumerable<T> entites) {
            foreach (var entity in entites) {
                if (!_set.Contains (entity)) {
                    _set.Add (entity);
                }
            }

            _context.SaveChanges ();
        }

        public void Remove (T entity) {
            _set.Remove (entity);
            _context.SaveChanges ();
        }
    }
}
