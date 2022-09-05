using System;
using System.Linq;
using System.Threading.Tasks;
using AtikYonetimSistemi.Models;

namespace AtikYonetimSistemi.Context
{
    public interface IMapperSession
    {

        //Generic type methods

        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        IQueryable<Container> Containers { get; }
        IQueryable<Vehicle> Vehicles { get; }

    }
}


