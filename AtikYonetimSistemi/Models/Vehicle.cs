using System;
namespace AtikYonetimSistemi.Models
{
	public class Vehicle
	{
		public virtual long id { get; set; }

		public virtual string vehicleName { get; set; }

		public virtual string vehiclePlate { get; set; }
	}
}
