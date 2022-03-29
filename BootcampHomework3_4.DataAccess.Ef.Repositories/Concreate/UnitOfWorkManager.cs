using BootcampHomework3_4.DataAccess.Ef.Repositories.Abstract;
using BootcampHomework3_4.DataAccess.EntityFramework;

namespace BootcampHomework3_4.DataAccess.Ef.Repositories.Concreate
{
    public class UnitOfWorkManager : IUnitOfWork
    {
        public Context _context { get; }

        public UnitOfWorkManager(Context context)
        {
            _context = context;
        }
        public void CommitAllOperations()
        {
            _context.SaveChanges();
        }
    }
}
