using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtikYonetimSistemi.Context;
using AtikYonetimSistemi.Mapping;
using AtikYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtikYonetimSistemi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ContainerController : ControllerBase
    {
        private readonly IMapperSession _session;


        public ContainerController(IMapperSession session)
        {
            _session = session;

        }

        //method that returns all containers
        [HttpGet]
        [Route("GetContainers")]
        public IActionResult Index()
        {
            var containers = _session.Containers.ToList();

            return Ok(containers);
        }

        //method that brings containers by vehicle
        [HttpGet]
        [Route("GetByVehicleId")]
        public IActionResult Get(int Id)
        {

            var vehiclesContainer = _session.Containers.ToList().Where(a => a.VehicleId == Id);

            return Ok(vehiclesContainer);
        }

        //method that add containers
        [HttpPost]
        public void Post([FromBody] Container container)
        {
            try
            {
                _session.BeginTransaction();
                _session.Save(container);
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
        public ActionResult<Container> Put([FromBody] Container request)
        {
            Container container = _session.Containers.Where(x => x.Id == request.Id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {
                _session.BeginTransaction();

                container.ContainerName = request.ContainerName;
                container.Latitude = request.Latitude;
                container.Longitude = request.Longitude;



                _session.Save(container);

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

        //method that delete container 
        [HttpDelete("{id}")]
        public ActionResult<Container> Delete(int id)
        {
            Container container = _session.Containers.Where(x => x.Id == id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {
                _session.BeginTransaction();
                _session.Delete(container);
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
