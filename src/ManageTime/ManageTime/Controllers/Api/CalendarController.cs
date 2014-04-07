using System.IO;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Http;
using KeepTime.Contracts;

namespace ManageTime.Controllers.Api
{
    [RoutePrefix("api/v1/calendar")]
    public class CalendarController: ApiController
    {
        [Route("")]
        public IHttpActionResult GetAllEntries()
        {
            Calendar cal = null;
            using(var file = new StreamReader(File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/calendar.json"))))
            {
                cal = Newtonsoft.Json.JsonConvert.DeserializeObject<Calendar>(file.ReadToEnd());
            }

            return Ok(cal);
        }
    }
}