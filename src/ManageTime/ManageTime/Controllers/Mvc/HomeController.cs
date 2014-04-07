using System.Web.Mvc;

namespace ManageTime.Controllers.Mvc
{
    public class HomeController: Controller
    {
        [Route("")]
        public ViewResult Home()
        {
            return View();
        }
    }
}