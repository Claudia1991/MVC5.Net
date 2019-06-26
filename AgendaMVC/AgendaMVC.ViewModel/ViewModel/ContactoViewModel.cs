using System.ComponentModel.DataAnnotations;

namespace AgendaMVC.Models.ViewModel
{
    public class ContactoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(20,ErrorMessage ="El campo {0} es muy largo.")]
        public string NombreContacto { get; set; }
        [StringLength(20, ErrorMessage = "El campo {0} es muy largo.")]
        public string ApellidoContacto { get; set; }
        [Required(ErrorMessage ="El {0} es requerido.")]
        public int TelefonoContacto { get; set; }
        [StringLength(30, ErrorMessage = "El campo {0} es muy largo.")]
        public string MailContacto { get; set; }
    }
}
