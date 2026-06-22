using Logica;
using Microsoft.AspNetCore.Mvc;

namespace ObligatorioWeb.Controllers.IncidenteCar
{
    public class IncidenteController : Controller
    {

        Sistema s = Sistema.Instancia;

        [HttpGet]
        public IActionResult ListadoIncidentes()
        {
            try
            {
                string rol = HttpContext.Session.GetString("rol");
                string cedula = HttpContext.Session.GetString("cedula");

                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(cedula))
                    return RedirectToAction("Login");
                if (HttpContext.Session.GetString("rol") == "ADMINISTRADOR")
                {

                    List<Incidente> inc = s.ObtenerIncidentes();


                    return View(inc);
                }
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<Activo>());
            }
        }
    }
}
