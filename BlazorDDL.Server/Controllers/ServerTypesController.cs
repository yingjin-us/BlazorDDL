using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDDL.Server.DataAcces;
using BlazorDDL.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorDDL.Server.Controllers
{
    [Route("api/[controller]")]
    public class ServerTypesController : Controller
    {
        DataAccessLayer objDal = new DataAccessLayer();
        // GET: api/<controller>
        [HttpGet]
        [Route("api/ServerTypes/GetServerTypesList")]
        public IEnumerable<ServerTypes> GetServerTypesList()
        {
            return objDal.GetAllServerTypes();
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/ServerTypes/GetServers")]
        public IEnumerable<Servers> GetServers(string id)
        {
            return objDal.GetServersData(id);
        }
    }
}
