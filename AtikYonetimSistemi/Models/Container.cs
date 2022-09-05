using System;
namespace AtikYonetimSistemi.Models
{
	public class Container
	{


		public virtual long Id { get; set; }

		public virtual string ContainerName { get; set; }

		public virtual Double Latitude { get; set; }

		public virtual Double Longitude { get; set; }

		public virtual long VehicleId { get; set; }

		


	}

}

