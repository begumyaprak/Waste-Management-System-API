
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

            //Id
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            //ContainerName
            Property(x => x.ContainerName , x => {
                x.Type(NHibernateUtil.String);
                x.Column("containername");
                x.Length(50);
            });


            //Latitude
            Property(x => x.Latitude , x => {
                x.Type(NHibernateUtil.Double);
                x.Column("latitude");
            });

            //Longitude
            Property(x => x.Longitude, x => {
                x.Type(NHibernateUtil.Double);
                x.Column("longitude");
            });

            //VehicleId
            Property(x => x.VehicleId,
               x =>
               {
                   x.Type(NHibernateUtil.Int64);
                   x.Column("vehicleid");
               });


            // table name for this mapping

            Table("container");
        }
    }
}

