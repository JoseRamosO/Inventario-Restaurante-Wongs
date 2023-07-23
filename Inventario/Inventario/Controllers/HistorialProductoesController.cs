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
    public class HistorialProductoesController : Controller
    {
        private InventarioEntities5 db = new InventarioEntities5();

        // GET: HistorialProductoes
        public ActionResult Index()
        {
            var historialProducto = db.HistorialProducto.Include(h => h.Producto);
            return View(historialProducto.ToList());
        }

        // GET: HistorialProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialProducto historialProducto = db.HistorialProducto.Find(id);
            if (historialProducto == null)
            {
                return HttpNotFound();
            }
            return View(historialProducto);
        }

        // GET: HistorialProductoes/Create
        public ActionResult Create()
        {
            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "Nombre");
            return View();
        }

        // POST: HistorialProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HistorialProductoID,Cantidad,Monto,Fecha,Accion,Descripcion,ProductoID,UnidadDeMedida")] HistorialProducto historialProducto)
        {
            if (ModelState.IsValid)
            {
                db.HistorialProducto.Add(historialProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "Nombre", historialProducto.ProductoID);
            return View(historialProducto);
        }

        // GET: HistorialProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialProducto historialProducto = db.HistorialProducto.Find(id);
            if (historialProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "Nombre", historialProducto.ProductoID);
            return View(historialProducto);
        }

        // POST: HistorialProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HistorialProductoID,Cantidad,Monto,Fecha,Accion,Descripcion,ProductoID,UnidadDeMedida")] HistorialProducto historialProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historialProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoID = new SelectList(db.Producto, "ProductoID", "Nombre", historialProducto.ProductoID);
            return View(historialProducto);
        }

        // GET: HistorialProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialProducto historialProducto = db.HistorialProducto.Find(id);
            if (historialProducto == null)
            {
                return HttpNotFound();
            }
            return View(historialProducto);
        }

        // POST: HistorialProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistorialProducto historialProducto = db.HistorialProducto.Find(id);
            db.HistorialProducto.Remove(historialProducto);
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
