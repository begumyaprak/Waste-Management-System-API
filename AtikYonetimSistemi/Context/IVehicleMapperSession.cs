using System;
using System.Linq;
using AtikYonetimSistemi.Models;

namespace AtikYonetimSistemi.Context
{
    public interface IVehicleMapperSession
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(Vehicle entity);
        void Update(Vehicle entity);
        void Delete(Vehicle entity);

        IQueryable<Vehicle> Vehicles { get; }
    }
}

