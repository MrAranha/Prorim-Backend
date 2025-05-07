using FbSoft_MediatrHandling.Interfaces;

namespace FbSoft_Services.Services
{
    public sealed class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly DbSession _session;


        private Dictionary<Type, object> _repositories;
        public UnitOfWork(DbSession session)
        {
            _session = session;
            _repositories = new Dictionary<Type, object>();
        }

        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => _session.Transaction?.Dispose();

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
