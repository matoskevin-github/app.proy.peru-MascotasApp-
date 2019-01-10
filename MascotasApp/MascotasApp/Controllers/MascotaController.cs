using MascotasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MascotasApp.Controllers
{
    public class MascotaController : Controller
    {
        // GET: Mascota
        [HttpGet]
        public ActionResult Index()

        {
            var listado = new List<Mascota>();
            if (Session["LisadoMascota"] == null)
            {
                listado = ObtenerMascotas();
                Session["LisadoMascota"] = listado;
            }
            else
            {
                listado = (List<Mascota>)Session["LisadoMascota"];
            }

            return View(listado.OrderBy(x => x.Id ).ToList());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Mascota oMascota)
        {
            List<Mascota> listado = (List<Mascota>)Session["LisadoMascota"];
            listado.Add(oMascota);
            Session["LisadoMascota"] = listado;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            var listado = (List<Mascota>)Session["LisadoMascota"];
            var oMascota = listado.FirstOrDefault(x => x.Id == Id);
            return View(oMascota);
        }

        [HttpPost]
        public ActionResult Actualizar(Mascota oMascota)
        {
            var listado = (List<Mascota>)Session["LisadoMascota"];
            var eMascota = listado.FirstOrDefault(x => x.Id == oMascota.Id);
            listado.Remove(eMascota);
            listado.Add(oMascota);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int Id)
        {
            var listado = (List<Mascota>)Session["LisadoMascota"];
            var oMascota = listado.FirstOrDefault(x => x.Id == Id);
            listado.Remove(oMascota);
            return RedirectToAction ("Index");
        }

        public List<Mascota> ObtenerMascotas()
        {
            List<Mascota> listado = new List<Mascota>();
            listado.Add(new Mascota() { Id = 1, Nombre = "Trusky", Raza = "Perro", Edad = 5, NombreDueno = "Claudia Martinez" });
            listado.Add(new Mascota() { Id = 2, Nombre = "Pepe", Raza = "Gato", Edad = 2, NombreDueno = "Sergio Lopez" });
            listado.Add(new Mascota() { Id = 3, Nombre = "Cirilo", Raza = "Loro", Edad = 4, NombreDueno = "Claudia Martinez" });
            listado.Add(new Mascota() { Id = 4, Nombre = "Guardian", Raza = "Perro", Edad = 1, NombreDueno = "Claudia Martinez" });
            listado.Add(new Mascota() { Id = 5, Nombre = "Babilonia", Raza = "Serpiente", Edad = 7, NombreDueno = "Claudia Martinez" });

            return listado;
        }
    }
}