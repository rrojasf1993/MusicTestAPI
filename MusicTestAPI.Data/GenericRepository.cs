using Microsoft.EntityFrameworkCore;
using MusicTestAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTestAPI.Data
{
    public class GenericRepository<TEntity> :  IRepository<TEntity> where TEntity : class
    {
        private MusicContext _context = null;
        private DbSet<TEntity> dbSet;

        public GenericRepository(MusicContext musicContext)
        {
            this._context = musicContext;
            this.dbSet = musicContext.Set<TEntity>();
        }
        public void Delete(object id)
        {
            TEntity itemToDelete = dbSet.Find(id);
            Delete(itemToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (this._context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetByID(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Insert(TEntity entityToInsert)
        {
            dbSet.Add(entityToInsert);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            this._context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
