using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtikYonetimSistemi.Context;
using AtikYonetimSistemi.Mapping;
using AtikYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Mapping.ByCode;

namespace AtikYonetimSistemi.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class VehicleController : ControllerBase
    {
        private readonly IVehicleMapperSession _session;


        public VehicleController(IVehicleMapperSession session)
        {
            _session = session;

        }


        [HttpGet]
        [Route("GetVehicles")]
        public IActionResult Index()
        {
            var vehicles = _session.Vehicle.ToList();

            return Ok(vehicles);
        }

        [HttpPost]
        public void Post([FromBody] Vehicle vehicle)
        {
            try
            {
                _session.BeginTransaction();
                _session.Save(vehicle);
                _session.Commit();
            }
            catch (Exception ex)
            {
                _session.Rollback();
               
            }
            finally
            {
                _session.CloseTransaction();
            }
        }

        [HttpPut]
        public ActionResult<Vehicle> Put([FromBody] Vehicle request)
        {
            Vehicle vehicle = _session.Vehicle.Where(x => x.id == request.id).FirstOrDefault();
            if (vehicle == null)
            {
                return NotFound();
            }

            try
            {
                _session.BeginTransaction();

                vehicle.vehiclename = request.vehiclename;
                vehicle.vehicleplate = request.vehicleplate;
                

                _session.Save(vehicle);

                _session.Commit();
            }
            catch (Exception ex)
            {
                _session.Rollback();
              
            }
            finally
            {
                _session.CloseTransaction();
            }


            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<Vehicle> Delete(int id)
        {
            Vehicle vehicle = _session.Vehicle.Where(x => x.id == id).FirstOrDefault();
            if (vehicle == null)
            {
                return NotFound();
            }

            try
            {
                _session.BeginTransaction();
                _session.Delete(vehicle);
                _session.Commit();
            }
            catch (Exception ex)
            {
                _session.Rollback();
                
            }
            finally
            {
                _session.CloseTransaction();
            }

            return Ok();
        }




    }
}

