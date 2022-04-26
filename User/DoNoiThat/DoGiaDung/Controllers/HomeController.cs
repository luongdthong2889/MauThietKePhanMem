using DoGiaDung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoGiaDung.Controllers
{
    public class HomeController : Controller
    {
        DBGiaDungEntities db = new DBGiaDungEntities();
        // GET: Product
        public ActionResult Index()     
        {
            return View(db.PRODUCTs.Take(12).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}