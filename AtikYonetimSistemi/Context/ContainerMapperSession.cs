using System;
using AtikYonetimSistemi.Mapping;
using NHibernate;
using System.Linq;
using AtikYonetimSistemi.Models;

namespace AtikYonetimSistemi.Context
{

    public class ContainerMapperSession : IContainerMapperSession
    {

        private readonly ISession session;
        private ITransaction transaction;

        public ContainerMapperSession(ISession session)
        {

            this.session = session;

        }

        public IQueryable<Container> Containers => session.Query<Container>();

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }


        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }


        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }


        public void Save(Container entity)
        {
            session.Save(entity);

        }

        public void Update(Container entity)
        {
            session.Save(entity);
        }


        public void Delete(Container entity)
        {
            session.Save(entity);
        }
    }

   
}

