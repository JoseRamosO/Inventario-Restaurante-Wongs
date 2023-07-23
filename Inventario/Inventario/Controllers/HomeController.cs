using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class HomeController : Controller
    {
        private InventarioEntities5 db = new InventarioEntities5();
        public ActionResult Index()
        {
            var stock = db.ViewProductoHistorial;
            return View(stock);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult CardView()
        {
            var stock = db.ViewProductoHistorial;
            return View( stock );
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}