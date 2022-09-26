using NEWSHORE.Entities.Interfaces;

namespace NEWSHORE.RepositoryEF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
