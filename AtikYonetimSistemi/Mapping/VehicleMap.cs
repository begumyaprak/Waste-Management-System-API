using System;
using AtikYonetimSistemi.Models;
using FluentNHibernate.MappingModel.ClassBased;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace AtikYonetimSistemi.Mapping
{
	public class VehicleMap: ClassMapping<Vehicle>
	{
        public VehicleMap()
        {
            Id(x => x.id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Identity);
                
            });

            Property(b => b.vehiclename, x => {
                x.Type(NHibernateUtil.String);
                x.Column("vehiclename");
                x.Length(50);
            });

            Property(b => b.vehicleplate, x => {
                x.Type(NHibernateUtil.String);
                x.Column("vehicleplate");
                x.Length(50);
            });


            Table("vehicle");
        }

    }
}

