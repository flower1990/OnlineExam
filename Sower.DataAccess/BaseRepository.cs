using Sower.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sower.DataAccess
{
    /// <summary>
    /// 仓储基类
    /// <remarks>
    /// 创建：2015.09.18
    /// 修改：2015.09.18
    /// </remarks>
    /// </summary>
    public class BaseRepository<T> : InterfaceBaseRepository<T> where T : class
    {
        protected SowerDbContext nContext = ContextFactory.GetCurrentContext();

        public IQueryable<T> Entities { get { return nContext.Set<T>(); } }

        public T Add(T entity, bool isSave = true)
        {
            nContext.Set<T>().Add(entity);
            if (isSave) nContext.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return nContext.Set<T>().Count(predicate);
        }

        public bool Update(T entity, bool isSave = true)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return isSave ? nContext.SaveChanges() > 0 : true;
        }

        public bool Delete(T entity, bool isSave = true)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return isSave ? nContext.SaveChanges() > 0 : true;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return nContext.Set<T>().Any(anyLambda);
        }

        public T Find(int ID)
        {
            return nContext.Set<T>().Find(ID);
        }

        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = nContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        public int Save() { return nContext.SaveChanges(); }
    }
}
