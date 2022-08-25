using System;
using System.Linq;
using AtikYonetimSistemi.Models;

namespace AtikYonetimSistemi.Context
{
    public interface IContainerMapperSession
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(Container entity);
        void Update(Container entity);
        void Delete(Container entity);

        IQueryable<Container> Containers { get; }
    }
}


