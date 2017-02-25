using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Models.Web
{
    public class WebConfiguration
    {
        public string WebSite { get; set; }
        public string UserName { get; set; }
        public Tokenmodel TokenModel { get; set; }
    }
    public class Tokenmodel
    {
        public int TimeOut { get; set; }
        public int MaxLength { get; set; }
    }
}
