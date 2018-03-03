using Lab02.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class TreeController : Controller
    {
        // GET: Tree
        public ActionResult Index()
        {
            return View();
        }


        // GET: Tree/StringTree
        public ActionResult PaisTree()
        {
            var path = @"C:\Users\apiro\OneDrive\Trabajos\trabajos de word\URL\2018\Ciclo III\Estructuras de datos\Lab\dataPaises.json";
            var contenido = System.IO.File.ReadAllText(path);
            var arbol = JsonConvert.DeserializeObject<Tree<Pais>>(contenido);

            var cadena = JsonConvert.SerializeObject(arbol);
            TempData["Tree"] = cadena;//Esto es como una variable para poder imprimir en la vista
            return View();
        }


        // GET: Tree/StringTree
        public ActionResult StringTree()
        {
            var path = @"C:\Users\apiro\OneDrive\Trabajos\trabajos de word\URL\2018\Ciclo III\Estructuras de datos\Lab\dataPaises.json";
            var contenido = System.IO.File.ReadAllText(path);
            var arbol = JsonConvert.DeserializeObject<Tree<string>>(contenido);

            var cadena = JsonConvert.SerializeObject(arbol);
            TempData["Tree"] = cadena;//Esto es como una variable para poder imprimir en la vista
            return View();
        }


        // GET: Tree/StringTree
        public ActionResult IntTree()
        {
            var path = @"C:\Users\apiro\OneDrive\Trabajos\trabajos de word\URL\2018\Ciclo III\Estructuras de datos\Lab\dataPaises.json";
            var contenido = System.IO.File.ReadAllText(path);
            var arbol = JsonConvert.DeserializeObject<Tree<int>>(contenido);

            var cadena = JsonConvert.SerializeObject(arbol);
            TempData["Tree"] = cadena;//Esto es como una variable para poder imprimir en la vista
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