using LockStep2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace LockStep2.Repo.Repositories
{
    public class GenericRepository<T> where T : class
    {
        internal ApplicationDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            return orderBy != null
                ? await orderBy(query).ToListAsync()
                : await query.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
             _context.SaveChanges();
        }

        public virtual async Task Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            await Delete(entityToDelete);
        }

        public virtual async Task Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}