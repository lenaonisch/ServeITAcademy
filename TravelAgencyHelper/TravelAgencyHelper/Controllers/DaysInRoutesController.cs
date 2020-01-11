using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyHelper.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgencyHelper.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DaysInRoutesController : Controller
    {
        IGenericRepository<DaysInRoute> repository;

        public DaysInRoutesController(IGenericRepository<DaysInRoute> repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IEnumerable<DaysInRoute> Get()
        {
            return repository.Get();
        }

        // GET: api/<controller/5
        //[HttpGet("{routeID}")]
        //public IEnumerable<DaysInRoute> Get(int routeID)
        //{
        //    return repository.FindById(routeID);
        //}

    }
}
