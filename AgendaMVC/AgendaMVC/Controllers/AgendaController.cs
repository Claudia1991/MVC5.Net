using AgendaMVC.Services.Services;
using AgendaMVC.Models.ViewModel;
using System.Web.Mvc;

namespace AgendaMVC.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Agenda
        public ActionResult Index()
        {
            //Trae todo el listado de los contactos.
            AgendaService agendaService = new AgendaService();
            var model = agendaService.GetList();

            return View(model);
        }

    }
}