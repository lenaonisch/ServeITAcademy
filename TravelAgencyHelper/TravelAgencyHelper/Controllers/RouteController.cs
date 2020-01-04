using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyHelper.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgencyHelper.Controllers
{
    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        ITravelAgencyRepository repository;

        public RouteController(ITravelAgencyRepository repo)
        {
            repository = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Route> Get()
        {
            return repository.Routes;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Route Get(int id)
        {
            return repository.Routes.Where(t=> t.Id == id).FirstOrDefault();
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
    }
}
