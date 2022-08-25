using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtikYonetimSistemi.Context;
using AtikYonetimSistemi.Mapping;
using Microsoft.AspNetCore.Mvc;



namespace AtikYonetimSistemi.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class VehicleController : ControllerBase
    {
        private readonly IVehicleMapperSession session;


        public VehicleController(IVehicleMapperSession session)
        {
            this.session = session;

        }



       

    }
}

