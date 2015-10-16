using Sower.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sower.Business
{
    /// <summary>
    /// 服务基类
    /// <remarks>创建：2015.09.18
    /// 修改：2015.09.18</remarks>
    /// </summary>
    public abstract class BaseService<T> where T : class
    {
        protected InterfaceBaseRepository<T> CurrentRepository { get; set; }

        public BaseService(InterfaceBaseRepository<T> currentRepository)
        {
            CurrentRepository = currentRepository;
        }

        public T Add(T entity)
        {
            return CurrentRepository.Add(entity);
        }

        public bool Update(T entity)
        {
            return CurrentRepository.Update(entity);
        }

        public bool Delete(T entity)
        {
            return CurrentRepository.Delete(entity);
        }

        public T Find(int ID)
        {
            return CurrentRepository.Find(ID);
        }

        public IQueryable<T> PageList(IQueryable<T> entitys, int pageIndex, int pageSize)
        {
            return entitys.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
