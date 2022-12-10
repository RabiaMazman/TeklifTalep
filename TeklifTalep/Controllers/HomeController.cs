using Microsoft.AspNetCore.Mvc;

namespace TeklifTalep.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("Teklif");
        }
    }
}
