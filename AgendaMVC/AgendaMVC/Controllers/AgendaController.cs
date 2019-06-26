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
        [HttpPost]
        public ActionResult AgregarContacto(ContactoViewModel contactoViewModel)
        {
            try
            {
                AgendaService agendaService = new AgendaService();
                var model = agendaService.Add(ParseContacto(contactoViewModel));
                return RedirectToAction("Detalle", "Agenda");
            }
            catch (System.Exception)
            {
                return View("Error");
            }
        }
        public ActionResult Eliminar(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("Error");
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return View();
        }
        public ActionResult Editar()
        {
            return View();
        }
        #endregion

        #region Private Methods
        private ContactoServiceModel ParseContacto(ContactoViewModel contactoViewModel)
        {
            return new ContactoServiceModel()
            {
                NombreContacto=contactoViewModel.NombreContacto,
                ApellidoContacto=contactoViewModel.ApellidoContacto,
                TelefonoContacto=contactoViewModel.TelefonoContacto,
                MailContacto=contactoViewModel.MailContacto
            };
        }
        #endregion
    }
}