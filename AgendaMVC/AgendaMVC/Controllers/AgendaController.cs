using AgendaMVC.Services.Services;
using AgendaMVC.Models.ViewModel;
using AgendaMVC.Models.ServiceModel;
using System.Web.Mvc;

namespace AgendaMVC.Controllers
{
    public class AgendaController : Controller
    {
        #region Public Methods
        public ActionResult Detalle()
        {
            try
            {
                AgendaService agendaService = new AgendaService();
                var model = agendaService.GetList();

                return View(model);
            }
            catch (System.Exception)
            {
                return View("Error");
            }
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
        #endregion

        #region Private Methods
        private bool AgregarContacto(ContactoViewModel contactoViewModel)
        {
            //aca se parsea con el contacto service model y se lo pasa como json a la weapi we.
            return true;
        }
        #endregion
    }
}