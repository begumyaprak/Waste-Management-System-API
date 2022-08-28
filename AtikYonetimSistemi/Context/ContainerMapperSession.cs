using System;
using AtikYonetimSistemi.Mapping;
using NHibernate;
using System.Linq;
using AtikYonetimSistemi.Models;
using System.Threading.Tasks;

namespace AtikYonetimSistemi.Context
{

    public class ContainerMapperSession : IContainerMapperSession
    {

        private readonly ISession _session;
        private ITransaction _transaction;

        public ContainerMapperSession(ISession session)
        {

            _session = session;

        }

        public IQueryable<Container> Container => _session.Query<Container>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }


        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }


        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }


        public async Task Save(Container entity)
        {
            await _session.SaveOrUpdateAsync(entity);

        }


        public async Task Delete(Container entity)
        {
           await _session.DeleteAsync(entity);
        }
    }

   
}

