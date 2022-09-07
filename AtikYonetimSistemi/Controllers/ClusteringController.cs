using AtikYonetimSistemi.Context;
using AtikYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
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
        public IActionResult GetGroups(int n, int id)
        {

            //başlangıç koordinatları
            var startLat = 41.067890;
            var startLong = 29.016060;

            //vehicle id'e göre listelenen containerlar
            var containers = _session.Containers.Where(a => a.VehicleId == id).ToList();


            //en yakından en  uzağa sıralandı 
             containers = containers.OrderBy(a => CalculateDistance(startLat, startLong, a.Latitude, a.Longitude)).ToList();

            //araca ait container sayısı n küme sayısına tam bölünmediği durumda mod alınır.           
            var mod = containers.Count() % n;

            var listItemCount = containers.Count() / n;
           
            if (mod > 0)
            {
                listItemCount= listItemCount + 1;
            }
            
            
            //oluşan grupların listesi
            var groups = new List<List<Container>>();

            //uzaklıklara göre ve n sayısına göre yeni kümeleri oluşturan for döngüsü 
            var counter = 0;
            for (int i = 0; i < n; i++)
            {
                var list = containers.Skip(counter).Take(listItemCount).ToList();
                groups.Add(list);
                counter = counter + listItemCount;
            }
           

            return Ok(groups);
        }

        [NonAction]
        //container mesafelerini hesaplayan fonksiyon
        private double CalculateDistance(double point1Lat, double point1Long, double point2Lat, double point2Long)
        {
            var d1 = point1Lat * (Math.PI / 180.0);
            var num1 = point1Long * (Math.PI / 180.0);
            var d2 = point2Lat * (Math.PI / 180.0);
            var num2 = point2Long * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
