using ApiRestCRUDMVC.Datos;
using ApiRestCRUDMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestCRUDMVC.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();

        [HttpGet]
        public IActionResult Listar()
        {
            // se mostrara una lista de contactos
            var viewLista = _contactoDatos.Listar();

            return View(viewLista);
        }

        public IActionResult Guardar()
        {
            //metodo  solo devuelve la vista
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel contacto)
        {
            // recibe el objeto y lo guarda en la bd

            if (!ModelState.IsValid) // valida que la información sea correcta.
                return View();

            var respuesta = _contactoDatos.Guardar(contacto);

            if(respuesta)
                return RedirectToAction("Listar"); // direcciona a la vista descrita
            else
                return View();            
        }

        public IActionResult Editar(int idContacto)
        {
            //editar
            var ocontacto = _contactoDatos.Obtener(idContacto);
            return View(ocontacto);
        }
        [HttpPost]
        public IActionResult Editar(ContactoModel contacto)
        {
            // recibe el objeto y lo guarda en la bd

            if (!ModelState.IsValid) // valida que la información sea correcta.
                return View();

            var respuesta = _contactoDatos.Editar(contacto);

            if (respuesta)
                return RedirectToAction("Listar"); // direcciona a la vista descrita
            else
                return View();
        }

        public IActionResult Eliminar(int idContacto) 
        {
            var ocontacto = _contactoDatos.Obtener(idContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel contacto)
        {
            var respuesta = _contactoDatos.Eliminar(contacto.idContacto);

            if (respuesta)
                return RedirectToAction("Listar"); // direcciona a la vista descrita
            else
                return View();
        }
    }
}
