using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyHelper.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgencyHelper.Controllers
{
    public class DaysInRoutesController : Controller
    {
        ITravelAgencyRepository repository;

        public DaysInRoutesController(ITravelAgencyRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IEnumerable<DaysInRoute> Get()
        {
            return repository.DaysInRoutes;
        }

        // GET: api/<controller/5
        [HttpGet("{routeID}")]
        public IEnumerable<DaysInRoute> Get(int routeID)
        {
            return repository.DaysOfRoute(routeID);
        }
    }
}
