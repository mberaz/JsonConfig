using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Configuration;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models.Configuration;
using Microsoft.Extensions.Options;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly AppConfiguration optionsAccessor;


        public ValuesController(  IOptions<AppConfiguration> _optionsAccessor)
        {
            optionsAccessor = _optionsAccessor.Value;
           
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var t = optionsAccessor.ApiName;
            var config = WebConfiguration.Insance();
            return new string[] { "value1", "value2" };
        }

        
    }
}
