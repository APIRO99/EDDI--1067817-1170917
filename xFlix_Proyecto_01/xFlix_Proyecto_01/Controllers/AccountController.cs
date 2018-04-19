using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xFlix_Proyecto_01.Models;

namespace xFlix_Proyecto_01.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbcontext db = new OurDbcontext())
            {
                TempData["uploadResult"] = "";
                try
                {
                     System.IO.File.WriteAllText(@"C:\Users\usuarios.json", "[" + Session["ARCHIVOJSON"].ToString() + "]");
                     TempData["uploadResult"] = "Archivo guardado en el disco con exito!";
                }
                catch (Exception ex)
                {
                    TempData["uploadResult"] = "Error" + ex.Message;

                }
                           
                return View(db.userAccount.ToList());
            }
       
        }
      
        public ActionResult Register()
        {
        
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbcontext db = new OurDbcontext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                    if (Session["ARCHIVOJSON"].ToString() == string.Empty)
                    {
                        Session["ARCHIVOJSON"] = JsonConvert.SerializeObject(account);
                    }
                    else
                    {
                        Session["ARCHIVOJSON"] = Session["ARCHIVOJSON"].ToString() + "," + JsonConvert.SerializeObject(account);
                    }
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered.";
            }

           
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDbcontext db = new OurDbcontext())
            {
                var usr = db.userAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (usr != null && usr.Username != "admin")
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else if ( usr.Username == "admin" && usr.Password == "admin")
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("Admin");
                }
                else
                {
                    ModelState.AddModelError("","UserName or Password is wrong.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Admin()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}