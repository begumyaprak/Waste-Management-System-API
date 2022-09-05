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
        private readonly IMapperSession _session;


        public VehicleController(IMapperSession session)
        {
            _session = session;

        }

        //method that returns all vehicles
        [HttpGet]
        [Route("GetVehicles")]
        public IActionResult Index()
        {
            var vehicles = _session.Vehicles.ToList();

            return Ok(vehicles);
        }


        //method that add vehicles
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
            Vehicle vehicle = _session.Vehicles.Where(x => x.Id == request.Id).FirstOrDefault();
            if (vehicle == null)
            {
                return NotFound();
            }

            try
            {
                _session.BeginTransaction();

                vehicle.VehicleName = request.VehicleName;
                vehicle.VehiclePlate = request.VehiclePlate;
                

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

        //method that delete vehicle 
        [HttpDelete("{id}")]
        public ActionResult<Vehicle> Delete(int id)
        {
            Vehicle vehicle = _session.Vehicles.Where(x => x.Id == id).FirstOrDefault();
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

