using System;
using System.Linq;
using System.Threading.Tasks;
using AtikYonetimSistemi.Models;

namespace AtikYonetimSistemi.Context
{
    public interface IVehicleMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Vehicle entity);
        Task Delete(Vehicle entity);

        IQueryable<Vehicle> Vehicle { get; }
    }
}

