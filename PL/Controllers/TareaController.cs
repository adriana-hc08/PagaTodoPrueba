using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class TareaController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
