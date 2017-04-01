namespace Configuration.Models
{
    public class WebConfiguration
    {

        public static WebConfiguration Instance(string environment = null)
        {
            return Cunfiguration.GetConfiguration<WebConfiguration>(environment);
        }

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
