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
    public class SacolaController : Controller
    {
        // GET: Sacola
        [Autenticar]
        public ActionResult Index()
        {
            Produtos Produtos = new Produtos();
            ViewBag.Sacola = Produtos.PRO_L_SACOLA(null).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string[] id)
        {
            string produtoNaoExistente = null;
            List<System.Collections.Generic.List<Business.PRO_L_SACOLA_Result>> objetoLista = new List<System.Collections.Generic.List<Business.PRO_L_SACOLA_Result>>();
            System.Collections.Generic.List<Business.PRO_L_SACOLA_Result> objeto = new System.Collections.Generic.List<Business.PRO_L_SACOLA_Result>();
            Produtos Produtos = new Produtos();

            foreach (var item in id)
            {
                objeto = Produtos.PRO_L_SACOLA(item).ToList();
                if (objeto.Count > 0)
                    objetoLista.Add(objeto.ToList());
                else
                    produtoNaoExistente += item + ",";
            }
            ViewBag.Retorno = objetoLista.ToList();
            if (ViewBag.Retorno != null)
            {
                if (produtoNaoExistente != null)
                    ViewBag.NaoExistente = produtoNaoExistente.Substring(0, produtoNaoExistente.Length - 1);
            }
            return View("retorno");
        }
    }
}