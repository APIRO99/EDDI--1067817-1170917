using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_04.Controllers
{
    public class DictionaryController : Controller
    {
        // GET: Dictionary
        public ActionResult Index()
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                        file.SaveAs(path);
                        TempData["uploadResult"] = "Archivo subido con éxito";
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["uploadResult"] = "Error" + ex.Message;

            }
            return View("Index");
        }

        // GET: Dictionary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dictionary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dictionary/Create
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

        // GET: Dictionary/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dictionary/Edit/5
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

        // GET: Dictionary/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dictionary/Delete/5
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
