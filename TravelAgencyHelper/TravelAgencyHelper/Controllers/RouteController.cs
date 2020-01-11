using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyHelper.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgencyHelper.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RouteController : Controller
    {
        IRoutesRepository repository;

        public RouteController(IRoutesRepository repo)
        {
            repository = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Route> Get()
        {
            return repository.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Route Get(int id)
        {
            return repository.FindById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }

        // GET: api/<controller/5
        [HttpGet("{routeID}")]
        public Route GetFullRoute(int routeID)
        {
            return repository.GetRouteWithDays(route=> route.Id == routeID);
        }
        
    }
}
