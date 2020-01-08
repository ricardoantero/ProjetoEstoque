using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Business;
using Estoque.App_Start;

namespace Estoque.Controllers
{
    [Autenticar]
    public class UsuariosController : Controller
    {
        private BLEstoque db = new BLEstoque();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.PRO_USU_USUARIO.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRO_USU_USUARIO pRO_USU_USUARIO = db.PRO_USU_USUARIO.Find(id);
            if (pRO_USU_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(pRO_USU_USUARIO);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USU_N_CODIGO,USU_C_NOME,USU_C_SENHA,USU_C_ATIVO")] PRO_USU_USUARIO pRO_USU_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.PRO_USU_USUARIO.Add(pRO_USU_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRO_USU_USUARIO);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRO_USU_USUARIO pRO_USU_USUARIO = db.PRO_USU_USUARIO.Find(id);
            if (pRO_USU_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(pRO_USU_USUARIO);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USU_N_CODIGO,USU_C_NOME,USU_C_SENHA,USU_C_ATIVO")] PRO_USU_USUARIO pRO_USU_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRO_USU_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRO_USU_USUARIO);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRO_USU_USUARIO pRO_USU_USUARIO = db.PRO_USU_USUARIO.Find(id);
            if (pRO_USU_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(pRO_USU_USUARIO);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRO_USU_USUARIO pRO_USU_USUARIO = db.PRO_USU_USUARIO.Find(id);
            db.PRO_USU_USUARIO.Remove(pRO_USU_USUARIO);
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
