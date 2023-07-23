using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario.Models;

namespace Inventario.Controllers
{
    [Authorize]
    public class ViewProductoHistorialsController : Controller
    {
        private InventarioEntities5 db = new InventarioEntities5();

        // GET: ViewProductoHistorials
        public ActionResult Index()
        {

            var uniqueProductNames = db.ViewProductoHistorial.GroupBy(item => item.NombreProducto).Select(group => group.FirstOrDefault()).ToList();
            var uniqueProviderNames = db.ViewProductoHistorial.GroupBy(item => item.NombreProveedor).Select(group => group.FirstOrDefault()).ToList();
            var uniqueType = db.ViewProductoHistorial.GroupBy(item => item.Tipo).Select(group => group.FirstOrDefault()).ToList();

            ViewBag.FiltroNombre = uniqueProductNames;
            ViewBag.FiltroProveedor = uniqueProviderNames;
            ViewBag.FiltroTipo = uniqueType;
            return View(db.ViewProductoHistorial.ToList());
        }
        public ActionResult FilteredData(string productName, string providerName, string type)
        {
            var filteredData = db.ViewProductoHistorial.AsQueryable();

            if (!string.IsNullOrEmpty(productName))
            {
                filteredData = filteredData.Where(item => item.NombreProducto == productName);
            }

            if (!string.IsNullOrEmpty(providerName))
            {
                filteredData = filteredData.Where(item => item.NombreProveedor == providerName);
            }

            if (!string.IsNullOrEmpty(type))
            {
                filteredData = filteredData.Where(item => item.Tipo == type);
            }

            return PartialView("_ProductTable", filteredData.ToList());
        }

        // GET: ViewProductoHistorials/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewProductoHistorial viewProductoHistorial = db.ViewProductoHistorial.Find(id);
            if (viewProductoHistorial == null)
            {
                return HttpNotFound();
            }
            return View(viewProductoHistorial);
        }

        // GET: ViewProductoHistorials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewProductoHistorials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NombreProducto,Tipo,NombreProveedor,CantidadTotal")] ViewProductoHistorial viewProductoHistorial)
        {
            if (ModelState.IsValid)
            {
                db.ViewProductoHistorial.Add(viewProductoHistorial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewProductoHistorial);
        }

        // GET: ViewProductoHistorials/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewProductoHistorial viewProductoHistorial = db.ViewProductoHistorial.Find(id);
            if (viewProductoHistorial == null)
            {
                return HttpNotFound();
            }
            return View(viewProductoHistorial);
        }

        // POST: ViewProductoHistorials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NombreProducto,Tipo,NombreProveedor,CantidadTotal")] ViewProductoHistorial viewProductoHistorial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewProductoHistorial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewProductoHistorial);
        }

        // GET: ViewProductoHistorials/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewProductoHistorial viewProductoHistorial = db.ViewProductoHistorial.Find(id);
            if (viewProductoHistorial == null)
            {
                return HttpNotFound();
            }
            return View(viewProductoHistorial);
        }

        // POST: ViewProductoHistorials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViewProductoHistorial viewProductoHistorial = db.ViewProductoHistorial.Find(id);
            db.ViewProductoHistorial.Remove(viewProductoHistorial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
