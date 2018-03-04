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
        Tree<string> TreeObjString;
        Tree<int> TreeObjInt;
        Tree<Pais> TreeObjPais;

        // GET: Tree
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tree/PaisTree
        public ActionResult PaisTree()
        {
            var path = @"C:\dataPaises.json";
            var contenido = System.IO.File.ReadAllText(path);
            TreeObjPais = JsonConvert.DeserializeObject<Tree<Pais>>(contenido);

            var cadena = JsonConvert.SerializeObject(TreeObjPais);
            TempData["Tree"] = cadena;//Esto es como una variable para poder imprimir en la vista

            TempData["EsDegenerado"] = TreeObjPais.EsDegenerado(TreeObjPais);
            TempData["EsLleno"] = TreeObjPais.EsLleno(TreeObjPais);
            return View();
        }

        // GET: Tree/StringTree
        public ActionResult StringTree()
        {
            var path = @"C:\dataString.json";
            var contenido = System.IO.File.ReadAllText(path);
            TreeObjString = JsonConvert.DeserializeObject<Tree<string>>(contenido);

            var cadena = JsonConvert.SerializeObject(TreeObjString);
            TempData["Tree"] = cadena;//Esto es como una variable para poder imprimir en la vista

            TempData["EsDegenerado"] = TreeObjString.EsDegenerado(TreeObjString);
            TempData["EsLleno"] = TreeObjString.EsLleno(TreeObjString);
            return View();
        }

        // GET: Tree/IntTree
        public ActionResult IntTree()
        {
            var path = @"C:\dataInt.json";
            var contenido = System.IO.File.ReadAllText(path);
            TreeObjInt = JsonConvert.DeserializeObject<Tree<int>>(contenido);

            var cadena = JsonConvert.SerializeObject(TreeObjInt);
            TempData["Tree"] = cadena;//Esto es como una variable para poder imprimir en la vista

            TempData["EsDegenerado"] = TreeObjInt.EsDegenerado(TreeObjInt);
            TempData["EsLleno"] = TreeObjInt.EsLleno(TreeObjInt);
            return View();
        }

        // GET: Tree/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tree/AddNode
        public ActionResult AddNode()
        {
            return View();
        }

        // POST: Tree/AddNode
        [HttpPost]
        public ActionResult AddNode(FormCollection collection)
        {
            try
            {
                if ()

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