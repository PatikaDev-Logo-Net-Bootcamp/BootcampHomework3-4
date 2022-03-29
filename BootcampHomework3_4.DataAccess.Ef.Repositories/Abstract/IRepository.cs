using BootcampHomework3_4.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BootcampHomework3_4.DataAccess.Ef.Repositories.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll();
        void Update(T entity);
        void Delete(int id);
    }
}
