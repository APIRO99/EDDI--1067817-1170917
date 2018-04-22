using Lab_001_Office.Classes; 
using Lab_001_Office.Models; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Lab_001_Office.Controllers
{
    public class MLSController : Controller
    {
        // GET: /Jugador/
        Stopwatch tiempo = new Stopwatch();
        public ActionResult Index()
        {
            // Envío la lista de jugadores
            return View(Data.Instance.Jugadores);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            tiempo.Reset();
            tiempo.Start();
            List<MLS> jugador = new List<MLS>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                string csvData = System.IO.File.ReadAllText(filePath);
                int line = 0;
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (line == 0)
                        {
                            line++;
                        }
                        else
                        {
                            Data.Instance.Jugadores.Add(new MLS
                            {
                                Club = row.Split(',')[0],
                                Apellido = row.Split(',')[1],
                                Nombre = row.Split(',')[2],
                                Posición = row.Split(',')[3],
                                Salario = Convert.ToDecimal(row.Split(',')[4]),

                            });
                        }
                    }
                }
            }
            tiempo.Stop();
            return RedirectToAction("Index");
        }

        //
        // GET: /Jugador/Details/5
        public ActionResult Details(int id)
        {
            // mostrar detalles del jugador que coincida el id
            var model = Data.Instance.Jugadores.FirstOrDefault(x => x.ID == id);
            return View(model);
        }

        //
        // GET: /Jugador/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Jugador/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            tiempo.Reset();
            tiempo.Start();
            try
            {
                // TODO: Add insert logic here
                var model = new MLS
                {
                    ID = Data.Instance.Jugadores.Count + 1,
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Posición = collection["Posición"],
                    Salario = Convert.ToDecimal(collection["Salario"]),
                    Club = collection["Club"]
                };

                Data.Instance.Jugadores.Add(model);
                tiempo.Stop();
                return RedirectToAction("Index");
            }
            catch
            {
                tiempo.Stop();
                return View();
            }
        }

        //
        // GET: /Jugador/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Data.Instance.Jugadores.FirstOrDefault(x => x.ID == id);
            return View(model);
        }

        //
        // POST: /Jugador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            tiempo.Reset();
            tiempo.Start();
            try
            {
                // TODO: Add update logic here
                var model = new MLS
                {
                    ID = id,
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Posición = collection["Posición"],
                    Salario = Convert.ToDecimal(collection["Salario"]),
                    Club = collection["Club"]
                };
                Data.Instance.Jugadores.Remove(Data.Instance.Jugadores.First(x => x.ID == id)); //Elimino el jugador que coincida el ID
                Data.Instance.Jugadores.Add(model); // Agrego el "nuevo" jugador (Realmente el jugador modificado)
                tiempo.Stop();
                return RedirectToAction("Index");
            }
            catch
            {
                tiempo.Stop();
                return View();
            }
        }

        //
        // GET: /Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Data.Instance.Jugadores.FirstOrDefault(x => x.ID == id);
            return View();
        }

        //
        // POST: /Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            tiempo.Reset();
            tiempo.Start();
            try
            {
                // TODO: Add delete logic here
                Data.Instance.Jugadores.Remove(Data.Instance.Jugadores.First(x => x.ID == id));
                tiempo.Stop();
                return RedirectToAction("Index");
            }
            catch
            {
                tiempo.Stop();
                return View();
            }
        }
    }
}