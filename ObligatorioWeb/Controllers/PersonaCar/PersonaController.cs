using Microsoft.AspNetCore.Mvc;

namespace ObligatorioWeb.Controllers.PersonaCar
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro() { return View(); }
        
        
    }
}
