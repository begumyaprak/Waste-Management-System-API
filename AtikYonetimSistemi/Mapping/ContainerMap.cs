
using System.Security.Cryptography.Xml;
using AtikYonetimSistemi.Models;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace AtikYonetimSistemi.Mapping
{
	public class ContainerMap : ClassMapping<Container>
	{
        public ContainerMap()
        {
            Id(x => x.id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Identity);
            });

            Property(b => b.containername);
            Property(b => b.latitude);
            Property(b => b.longitude);


            ///??
         
            ManyToOne(x => x.vehicle, x => x.Column("vehicleId"));

            ///

            Table("container");
        }
    }
}

