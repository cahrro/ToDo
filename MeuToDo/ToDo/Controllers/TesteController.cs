using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
} 
