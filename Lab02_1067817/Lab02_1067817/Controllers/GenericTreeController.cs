using Lab02_1067817.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02_1067817.Controllers
{
    public class TreeController<T> : Controller
    {
        // GET: Tree
        public ActionResult Index()
        {
            var path = @"C:\Users\apiro\OneDrive\Trabajos\trabajos de word\URL\2018\Ciclo III\Estructuras de datos\Lab\dataPaises.json";
            var contenido = System.IO.File.ReadAllText(path);
            var arbol = JsonConvert.DeserializeObject<Tree<T>>(contenido);

            var cadena = JsonConvert.SerializeObject(arbol);
            TempData["Arbol"] = cadena;

            return View();
        }

        // GET: Tree/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tree/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tree/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tree/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tree/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tree/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
