using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyHelper.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgencyHelper.Controllers
{
    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        IRoutesRepository repository;

        public RouteController(IRoutesRepository repo)
        {
            repository = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = repository.FindById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/<controller>/Name="Сванетия"
        [HttpGet("Search/{searchString}")]
        public IActionResult Search(string searchString)
        {
            //Route route = Helpers.ControllerHelper<Route>.GetFromQueryString(searchString);
            var result = repository.Get(route=> route.Name.Contains(searchString));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Route value)
        {
            return Ok(repository.Create(value));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Route value)
        {
            value.Id = id;
                
            if (repository.Update(value))
            {
                return Ok();
            }

            return NotFound();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (repository.SoftRemove(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("Erase/{id}")]
        public void Erase(int id)
        {
            repository.Erase(id);
        }

        // GET: api/<controller/5
        [HttpGet("Full/{routeID}")]
        public IActionResult GetFullRoute(int routeID)
        {
            var result = repository.GetRouteWithDays(route => route.Id == routeID);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/<controller/5
        [HttpGet("RouteCountries/{routeID}")]
        public IActionResult GetCountryList(int routeID)
        {
            var result = repository.GetCountries(routeID);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
