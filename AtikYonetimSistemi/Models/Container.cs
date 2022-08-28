using System;
namespace AtikYonetimSistemi.Models
{
	public class Container
	{
		public virtual int id { get; set; }

		public virtual string containername { get; set; }

		public virtual Double latitude { get; set; }

		public virtual Double longitude { get; set; }

		public virtual int vehicleId { get; set; }

		public virtual Vehicle vehicle { get; set; }







	}

}

