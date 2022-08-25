using System;
using NHibernate;
using System.Linq;
using AtikYonetimSistemi.Models;
using AtikYonetimSistemi.Context;

namespace AtikYonetimSistemi.Mapping
{

    public class VehicleMapperSession : IVehicleMapperSession
    {

        private readonly ISession session;
        private ITransaction transaction;

        public VehicleMapperSession(ISession session)
        {

            this.session = session;

        }

        public IQueryable<Vehicle> Vehicles => session.Query<Vehicle>();

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


        public void Save(Vehicle entity)
        {
            session.Save(entity);

        }

        public void Update(Vehicle entity)
        {
            session.Save(entity);
        }


        public void Delete(Vehicle entity)
        {
            session.Save(entity);
        }






    }
}
