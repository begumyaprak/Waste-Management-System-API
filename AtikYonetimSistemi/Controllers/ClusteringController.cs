using AtikYonetimSistemi.Context;
using AtikYonetimSistemi.Models;
using FluentNHibernate.Testing.Values;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Engine.Query;
using System.Collections.Generic;
using System.Linq;

namespace AtikYonetimSistemi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ClusteringController : ControllerBase
    {
        private readonly IMapperSession _session;


        public ClusteringController(IMapperSession session)
        {
            _session = session;

        }


        [HttpGet]
        public ActionResult<List<Container>> GetClustering(long id, int clusterNumber)
        {
            List<Container> vehicleContainerList = _session.Containers.Where(a => a.VehicleId == id).ToList();

            var response = vehicleContainerList.Select((x, i) => new { Index = i, value = x })
                .GroupBy(x => x.Index % clusterNumber)
                .Select(x => x.Select(a => a.value).ToList())
                .ToList();

            return Ok(response);

        }
    }
}