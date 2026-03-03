using Microsoft.AspNetCore.Mvc;

namespace MonolithAPI.Controllers
{
    public class AuthApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
