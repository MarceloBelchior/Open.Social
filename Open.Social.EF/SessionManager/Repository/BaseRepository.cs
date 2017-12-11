using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Open.Social.EF.SessionManager.Repository
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : class, new()
    {
        protected Context.DBOpen Context;

        public BaseRepository()
        {
            Context = new Context.DBOpen();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> where = null,
            IOrderByClause<TEntity>[] orderBy = null, int skip = 0, int top = 0, string[] include = null)
        {
            try
            {
                IQueryable<TEntity> data = Context.Set<TEntity>();

                if (where != null)
                {
                    data = data.Where(where);
                }

                if (orderBy != null)
                {
                    bool isFirstSort = true;

                    orderBy.ToList().ForEach(one =>
                    {
                        data = one.ApplySort(data, isFirstSort);
                        isFirstSort = false;
                    });
                }

                if (skip > 0)
                {
                    data = data.Skip(skip);
                }
                if (top > 0)
                {
                    data = data.Take(top);
                }

                if (include != null)
                {
                    include.ToList().ForEach(one => data = data.Include(one));
                }

                foreach (TEntity item in data)
                {
                    yield return item;
                }
            }
            finally
            {
            }
        }

        public virtual TEntity SelectById(long ID)
        {
            try
            {
                return Context.Set<TEntity>().Find(ID);
            }
            finally
            {
            }
        }

        public virtual TEntity Insert(TEntity item, bool saveImmediately = true)
        {
            try
            {
                DbSet<TEntity> set = Context.Set<TEntity>();

                set.Add(item);

                if (saveImmediately)
                {
                    Context.SaveChanges();
                }

                return item;
            }
            finally
            {
            }
        }

        public virtual TEntity Update(TEntity item, bool saveImmediately = true)
        {
            try
            {
                DbSet<TEntity> set = Context.Set<TEntity>();

                EntityEntry<TEntity> entry = Context.Entry(item);

                if (entry != null)
                {
                    entry.State = EntityState.Modified;
                }
                else
                {
                    set.Attach(item);

                    Context.Entry(item).State = EntityState.Modified;
                }

                if (saveImmediately)
                {
                    Context.SaveChanges();
                }

                return item;
            }
            finally
            {
            }
        }

        public virtual void Remove(TEntity item)
        {
            DbSet<TEntity> set = Context.Set<TEntity>();
            set.Remove(item);

        }

        //public virtual void Delete(TEntity item, bool saveImmediately = true)
        //{
        //    try
        //    {
        //        DbSet<TEntity> set = Context.Set<TEntity>();

        //        DbEntityEntry<TEntity> entry = Context.Entry(item);

        //        if (entry != null)
        //        {
        //            entry.State = EntityState.Deleted;
        //        }
        //        else
        //        {
        //            set.Attach(item);

        //            Context.Entry(item).State = EntityState.Deleted;
        //        }

        //        if (saveImmediately)
        //        {
        //            Context.SaveChanges();
        //        }
        //    }
        //    finally
        //    {
        //    }
        //}

        public virtual TEntity AttachWithAddState(TEntity item)
        {

            DbSet<TEntity> set = Context.Set<TEntity>();
            set.Attach(item);
            Context.Entry(item).State = EntityState.Added;
            return item;


        }

        public virtual TEntity Attach(TEntity item)
        {

            DbSet<TEntity> set = Context.Set<TEntity>();
            set.Attach(item);
            return item;


        }

        //public virtual void Save()
        //{
        //    Context.SaveChanges();

        //    ((IObjectContextAdapter)Context).ObjectContext.AcceptAllChanges();
        //}

        ~BaseRepository()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
        }
    }
}