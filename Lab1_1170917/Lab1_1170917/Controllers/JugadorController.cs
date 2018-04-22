using Lab1_1170917.Class; // Referencia del folder class donde esta la clase Data
using Lab1_1170917.Models; // Modelo de referencia de jugador
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Lab1_1170917.Controllers
{
    public class JugadorController : Controller
    {
        DefaultConnection db = DefaultConnection.getInstance;
        // GET: /Jugador/
        Stopwatch tiempo = new Stopwatch();
        public ActionResult Index(string searchString)
        {
            var jugadores = from s in Data.Instance.Jugadores
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                jugadores = jugadores.Where(s => s.Apellido.Contains(searchString)
                                       || s.Nombre.Contains(searchString) || s.Club.Contains(searchString) || s.Posición.Contains(searchString));
            }
            // Envío la lista de jugadores
            return View(Data.Instance.Jugadores);
            
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            tiempo.Reset();
            tiempo.Start();
            List<Jugador> jugador = new List<Jugador>();
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
                            Data.Instance.Jugadores.Add(new Jugador
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
                var model = new Jugador
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
                var model = new Jugador
                {
                    ID = id,
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Posición = collection["Posición"],
                    Salario = Convert.ToDecimal(collection["Salario"]),
                    Club = collection["Club"]
                };
                Data.Instance.Jugadores.Remove(Data.Instance.Jugadores.First(x => x.ID == id)); //Elimina al jugador con el mismo ID
                Data.Instance.Jugadores.Add(model); // Se agrega un nuevo jugador
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
                // TODO: Se agregan los eliminados
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