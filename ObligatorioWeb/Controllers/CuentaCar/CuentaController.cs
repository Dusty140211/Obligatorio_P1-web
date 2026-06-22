using Logica;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_P1;

namespace ObligatorioWeb.Controllers.CuentaCar
{
    public class CuentaController : Controller
    {

        Sistema s = Sistema.Instancia;
        public IActionResult listarCuentas(string id)
        {
            try
            {
                List<Cuenta> cuentas;
                if (HttpContext.Session.GetString("rol") == "ADMINISTRADOR")
                {


                    Persona p = s.ObtenerPersona(id);
                    cuentas = s.listarCuenta(p);
                    return View(cuentas);

                }
                return View();
            }
            catch
            {
                ViewBag.Error = "Error al obtener las cuentas";
                return View();
            }

        }

        public IActionResult CrearCuenta(string cedulaPersona)
        {
            try
            {

                ViewBag.CedulaPersona = cedulaPersona;

                return View(new Cuenta());

            }
            catch
            {
                ViewBag.Error = "Error al obtener los activos de la persona";
                return View();
            }
        }
        [HttpPost]
        public IActionResult CrearCuenta(Cuenta c, string id)
        {
            try
            {
                Persona pBuscada = s.ObtenerPersona(id);
                c.UCContrase = DateTime.Now;
                c.Titular = pBuscada;
                s.altaCuenta(c);

                return RedirectToAction("listarCuentas", new { id = id });
            }
            catch
            {
                ViewBag.Error = "Error al obtener los activos de la persona";
                return View();
            }

        }
    }
}
