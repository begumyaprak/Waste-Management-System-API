
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

            Property(b => b.containername , x => {
                x.Type(NHibernateUtil.String);
                x.Column("containername");
                x.Length(50);
            });

            Property(b => b.latitude , x => {
                x.Type(NHibernateUtil.Double);
                x.Column("latitude");
            });


            Property(b => b.longitude, x => {
                x.Type(NHibernateUtil.Double);
                x.Column("longitude");
            });


          

            Table("container");
        }
    }
}

