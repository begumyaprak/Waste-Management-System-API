using System;
using System.Linq;
using System.Threading.Tasks;
using AtikYonetimSistemi.Models;

namespace AtikYonetimSistemi.Context
{
    public interface IContainerMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Container entity);
        Task Delete(Container entity);

        IQueryable<Container> Container { get; }

    }
}


