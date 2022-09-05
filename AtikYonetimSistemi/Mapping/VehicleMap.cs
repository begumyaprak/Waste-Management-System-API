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
            //Id
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
                
            });
            //VehicleName
            Property(x => x.VehicleName, x => {
                x.Type(NHibernateUtil.String);
                x.Column("vehiclename");
                x.Length(50);
            });

            //VehiclePlate
            Property(x => x.VehiclePlate, x => {
                x.Type(NHibernateUtil.String);
                x.Column("vehicleplate");
                x.Length(50);
            });

            // table name for this mapping
            Table("vehicle");
        }

    }
}

