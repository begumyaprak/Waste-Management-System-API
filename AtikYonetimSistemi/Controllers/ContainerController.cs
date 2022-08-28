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
        private readonly IContainerMapperSession _session;


        public ContainerController(IContainerMapperSession session)
        {
            _session = session;

        }


        [HttpGet]
        [Route("GetContainers")]
        public IActionResult Index()
        {
            var containers = _session.Container.ToList();

            return Ok(containers);
        }


        [HttpGet]
        [Route("GetByVehicleId")]
        public IActionResult Get(int Id)
        {

            var vehiclesContainer = _session.Container.ToList().Where(a => a.vehicleId == Id).FirstOrDefault();

            return Ok(vehiclesContainer);
        }

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
            Container container = _session.Container.Where(x => x.id == request.id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {
                _session.BeginTransaction();

                container.containername = request.containername;
                container.latitude = request.latitude;
                container.longitude = request.longitude;



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


        [HttpDelete("{id}")]
        public ActionResult<Container> Delete(int id)
        {
            Container container = _session.Container.Where(x => x.id == id).FirstOrDefault();
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



        //[HttpGet]
        //[Route("GetNNumber")]
        //public IActionResult GetNumber(int id, int N)
        //{
        //    var vehiclesContainer = _session.Container.ToList().Where(a => a.vehicleId == id);


        //    if (vehiclesContainer.Count() % N == 0)
        //    {
        //        var list = new List<>;

        //        foreach (var item in vehiclesContainer)
        //        {

        //        }

        //    }


        //    return Ok();

        //}
    }



}
