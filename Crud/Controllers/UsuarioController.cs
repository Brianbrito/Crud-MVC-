using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuari/ muestra el  listado
        public ActionResult Index()
        {
            CRUDEntities db = new CRUDEntities();
                                                        // consulta LinQ para mostrar el listado de los usuarios.
            return View(db.Registro.ToList());
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Registro r)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using ( var db = new CRUDEntities())  //para que no quede una conexion abrierta y consuma recursos

                {
                    db.Registro.Add(r);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error al agregar usuario", ex);
                return View();
            }

           
              
        }



    }
}