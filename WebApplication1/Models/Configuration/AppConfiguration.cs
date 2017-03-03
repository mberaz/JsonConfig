using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Configuration
{
    public class AppConfiguration
    {
        public string Environment { get; set; }
        public string ApiName { get; set; }

        public WebConfiguration Web { get; set; }
    }
}
