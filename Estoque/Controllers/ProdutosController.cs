using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Business;
using System.IO;
using Estoque.App_Start;

namespace Estoque.Controllers
{
    [Autenticar]
    public class ProdutosController : Controller
    {
        private BLEstoque db = new BLEstoque();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(db.PRO_PRO_PRODUTO.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRO_PRO_PRODUTO pRO_PRO_PRODUTO = db.PRO_PRO_PRODUTO.Find(id);
            if (pRO_PRO_PRODUTO == null)
            {
                return HttpNotFound();
            }
            return View(pRO_PRO_PRODUTO);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRO_N_CODIGO,PRO_N_REFERENCIA,PRO_C_NOME,PRO_C_DESCRICAO,PRO_C_MARCA,PRO_C_COR,PRO_C_VALOR,PRO_C_VALOR_VENDA,PRO_C_PORCENTAGEM,PRO_D_DATA_CADASTRO,PRO_D_DATA_VENDA,PRO_C_TAMANHO,PRO_N_SITUACAO,PRO_C_IMAGEM,PRO_B_ATIVO")] PRO_PRO_PRODUTO pRO_PRO_PRODUTO, HttpPostedFileBase image)
        {
            if(ModelState.IsValid)
            {
                db.PRO_PRO_PRODUTO.Add(pRO_PRO_PRODUTO);
                db.SaveChanges();
                if(image != null)
                    UploadFiles(image, pRO_PRO_PRODUTO.PRO_N_CODIGO);
               
                return RedirectToAction("Index");
            }

            return View(pRO_PRO_PRODUTO);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRO_PRO_PRODUTO pRO_PRO_PRODUTO = db.PRO_PRO_PRODUTO.Find(id);
            if (pRO_PRO_PRODUTO == null)
            {
                return HttpNotFound();
            }
           
            return View(pRO_PRO_PRODUTO);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRO_N_CODIGO,PRO_N_REFERENCIA,PRO_C_NOME,PRO_C_DESCRICAO,PRO_C_MARCA,PRO_C_COR,PRO_C_VALOR,PRO_C_VALOR_VENDA,PRO_C_PORCENTAGEM,PRO_D_DATA_CADASTRO,PRO_D_DATA_VENDA,PRO_C_TAMANHO,PRO_N_SITUACAO,PRO_C_IMAGEM,PRO_B_ATIVO")] PRO_PRO_PRODUTO pRO_PRO_PRODUTO, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
              
                db.Entry(pRO_PRO_PRODUTO).State = EntityState.Modified;
                db.Entry(pRO_PRO_PRODUTO).Property(x => x.PRO_C_IMAGEM).IsModified = false;
                db.SaveChanges();

                if (image != null)
                {
                    UploadFiles(image, pRO_PRO_PRODUTO.PRO_N_CODIGO);
                }
             
                return RedirectToAction("Index");
            }
            return View(pRO_PRO_PRODUTO);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRO_PRO_PRODUTO pRO_PRO_PRODUTO = db.PRO_PRO_PRODUTO.Find(id);
            if (pRO_PRO_PRODUTO == null)
            {
                return HttpNotFound();
            }
            return View(pRO_PRO_PRODUTO);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRO_PRO_PRODUTO pRO_PRO_PRODUTO = db.PRO_PRO_PRODUTO.Find(id);
            db.PRO_PRO_PRODUTO.Remove(pRO_PRO_PRODUTO);
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

        [HttpPost]  
        public ActionResult UploadFiles(HttpPostedFileBase image, int idProduto)
        {
            if (image != null)
            {
                try
                {
                    var guid = System.Guid.NewGuid().ToString("N");
                    string extension = Path.GetExtension(image.FileName);
                    var nome = Server.MapPath("~/Imagens/" + guid + extension);
                    var CaminhoVirtual = "/Imagens/" + guid + extension;

                    image.SaveAs(nome);

                    Produtos Produtos = new Produtos();
                    Produtos.PRO_I_IMAGEM(CaminhoVirtual, idProduto);

                    return View();
                }
                catch (Exception ex)
                {
                    return Json("Erro ao fazer upload de Imagem: " + ex.Message);
                }
            }
            else
            {
                return Json("Nenhuma imagem selecionada.");
            }
        }
    }
}
