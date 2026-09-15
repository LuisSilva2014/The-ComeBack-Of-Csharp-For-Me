using AutoManager2.Application.Entities;
using AutoManager2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AutoManager2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController: ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<ActionResult> GetAll()
        {
            var vehicles = await _vehicleService.GetAllAsync();

            //var vehiclesMock = new Vehicle()
            //{
            //    Id = new Guid(),
            //    Make = "Toyota",
            //    Model = "2011",
            //    Vin = "dasdsadas"
            //};

            //string[] s = ["1", "2"];
            return Ok(vehicles); // serializes a json automatically

            //------------- legacy code using ASP.NET MVC === reqquireds Newtonsoft.Json 
            //
            //no any more in .core as it internally uses System.Text.Json 
            //var json = JsonConvert.SerializeObject(vehicles);
            //return Content(json, "application/json");
            //string json1 =
            //@"{
            //    ""Id"": 1,
            //    ""Vin"": ""12345"",
            //    ""Make"": ""Ford""
            //}";
            ////Deserialize 
            //Vehicle vehicle = JsonConvert.DeserializeObject<Vehicle>(json1);


        }
    }
}
