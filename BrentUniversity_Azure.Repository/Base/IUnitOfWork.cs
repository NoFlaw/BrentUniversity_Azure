using System;

namespace BrentUniversity_Azure.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        void Commit();
    }
}
