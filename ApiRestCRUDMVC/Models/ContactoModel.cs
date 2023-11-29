using System.ComponentModel.DataAnnotations; // para validaciones

namespace ApiRestCRUDMVC.Models
{
    public class ContactoModel
    {
        public int idContacto { get; set; }
        [Required(ErrorMessage ="El campo nombre es obligatorio")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo telefono es obligatorio")]
        public string telefono { get; set; }
        [Required(ErrorMessage = "El campo correo es obligatorio")] 
        public string correo { get; set; }





    }
}
