using Lab02.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class StringTreeController : Controller
    {
        Tree<string> ObjTree;

        // GET: StringTree
        public ActionResult Index()
        {
            if (ObjTree == null)
            {
                var path = @"C:\dataString.json";
                var contenido = System.IO.File.ReadAllText(path);
                ObjTree = JsonConvert.DeserializeObject<Tree<string>>(contenido);

                var cadena = JsonConvert.SerializeObject(ObjTree);
                TempData["Tree"] = cadena;//Esto es como una variable para poder imprimir en la vista
            }
            else
            {
                var cadena = JsonConvert.SerializeObject(ObjTree);
                TempData["Tree"] = cadena;//Esto es como una variable para poder imprimir en la vista
            }
            return View();
        }

        // GET: StringTree/Details/5
        public ActionResult Details(int id)
        {
            return View();

        }

        // GET: StringTree/NewStringNode
        public ActionResult NewStringNode()
        {
            return View();
        }

        // POST: StringTree/NewStringNode
        [HttpPost]
        public ActionResult NewStringNode(FormCollection collection)
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

        // GET: StringTree/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StringTree/Edit/5
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

        // GET: StringTree/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StringTree/Delete/5
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
