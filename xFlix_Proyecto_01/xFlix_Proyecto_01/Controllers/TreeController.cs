using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace xFlix_Proyecto_01.Controllers
{
    public class TreeController : Controller
    {
        // GET: Tree
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarUsuario()
        {
            return View();
        }
        public ActionResult EliminarAdmin()
        {
            return View();
        }
        public ActionResult EliminarUsuario()
        {
            return View();
        }
        public ActionResult IngresoArchivo()
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
                      // Agregar al catalogo  dictionary = JsonConvert.DeserializeObject<Dictionary<string, myDictionary>>(content);
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["uploadResult"] = "Error" + ex.Message;

            }
            return View(/*"Index"*/);
        }
        public ActionResult IngresoManual()
        {
            return View();
        }
    }
}