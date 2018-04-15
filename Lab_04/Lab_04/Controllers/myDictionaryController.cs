using Lab_04.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_04.Controllers
{
    public class myDictionaryController : Controller
    {
        Dictionary<string, myDictionary> dictionary;
        Dictionary<string, bool> Checking;

        // GET: Dictionary
        public ActionResult Index()
        {
            return View();
        }

        //GET: Dictionary/Upload
        public ActionResult Upload()
        {
            TempData["uploadResult"] = "";
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

                        var content = System.IO.File.ReadAllText(path);
                        dictionary = JsonConvert.DeserializeObject<Dictionary<string, myDictionary>>(content);
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["uploadResult"] = "Error" + ex.Message;

            }
            return View(/*"Index"*/);
        }//Tested


        //GET: Dictionary/UploadC
        public ActionResult UploadC()
        {
            TempData["uploadResult"] = "";
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

                        var content = System.IO.File.ReadAllText(path);
                        Checking = JsonConvert.DeserializeObject<Dictionary<string, bool>>(content);

                    }
                }

            }
            catch (Exception ex)
            {
                TempData["uploadResult"] = "Error" + ex.Message;

            }
            return View(/*"Index"*/);
        }//Tested



        // GET: Dictionary/myDetails/5
        public ActionResult myDetails(int id)
        {
            return View();
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

    public class Pais
    {
        public Dictionary<string, JsonObjectAttribute> faltantes;
        public Dictionary<string, JsonObjectAttribute> coleccionadas;
        public Dictionary<string, JsonObjectAttribute> cambios;
        //public List<int> coleccionadas;
        //public List<int> cambios;

    }  
}
