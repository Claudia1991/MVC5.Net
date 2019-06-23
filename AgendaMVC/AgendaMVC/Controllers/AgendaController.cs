using AgendaMVC.Services.Services;
using AgendaMVC.Models.ViewModel;
using System.Web.Mvc;

namespace AgendaMVC.Controllers
{
    public class AgendaController : Controller
    {
        public ActionResult Detalle()
        {
            //Trae todo el listado de los contactos.
            AgendaService agendaService = new AgendaService();
            var model = agendaService.GetList();

            return View(model);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        public ActionResult Eliminar()
        {
            return View();
        }
        public ActionResult Editar()
        {
            return View();
        }

    }
}