using BootcampHomework3_4.DataAccess.Ef.Repositories.Abstract;
using BootcampHomework3_4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BootcampHomework3_4.DataAccess.Ef.Repositories.Concreate
{
    public class RepositoryManager<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unit;

        public RepositoryManager(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public void Delete(int id)
        {
            T exist = _unit._context.Set<T>().FirstOrDefault(x => x.ID == id);
            if (exist != null)
            {
                exist.IsDeleted = true;
                _unit._context.Entry(exist).State = EntityState.Modified;
                _unit.CommitAllOperations();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            T exist = _unit._context.Set<T>().FirstOrDefault(filter);
            if (exist == null)
            {
                throw new InvalidOperationException("This entity not found");
            }
            return exist;
        }

        public IQueryable<T> GetAll()
        {
            return _unit._context.Set<T>().Where(x => !x.IsDeleted).AsQueryable();
        }

        public void Update(T entity)
        {
            _unit._context.Entry(entity).State = EntityState.Modified;
        }
    }
}
