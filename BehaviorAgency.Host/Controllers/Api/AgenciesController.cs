using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BehaviorAgency.Host.Controllers.Api
{
    [Route("api/agencies")]
    public class AgenciesController : Controller
    {
        // GET: api/Agencies
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Agencies/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
       
        
        // PUT: api/Agencies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
       
    }
}
