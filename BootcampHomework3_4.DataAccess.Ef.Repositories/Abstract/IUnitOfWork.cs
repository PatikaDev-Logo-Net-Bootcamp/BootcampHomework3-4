using BootcampHomework3_4.DataAccess.EntityFramework;

namespace BootcampHomework3_4.DataAccess.Ef.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        public Context _context { get; }
        void CommitAllOperations();
    }
}
