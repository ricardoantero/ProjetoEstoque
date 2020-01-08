using Business;
using Estoque.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Estoque.Controllers
{

    public class LoginController : Controller
    {
        public ActionResult Index(string login, string senha)
        {
            return View();
        }

        public ActionResult Sair()
        {
            this.Session["autorizado"] = false;
            this.Session["login"] = null;
            return View("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(PRO_USU_USUARIO autenticacao, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (BLEstoque db = new BLEstoque())
                {
                    PRO_USU_USUARIO usuario = new PRO_USU_USUARIO();

                    if (autenticacao.USU_C_NOME != null && autenticacao.USU_C_SENHA != null)
                        usuario = db.PRO_USU_USUARIO.FirstOrDefault(x => x.USU_C_NOME == autenticacao.USU_C_NOME && x.USU_C_SENHA == autenticacao.USU_C_SENHA);

                    if (usuario != null)
                    {
                        if (Equals(usuario.USU_C_ATIVO, true))
                        {
                            if (Equals(usuario.USU_C_SENHA, autenticacao.USU_C_SENHA))
                            {
                                FormsAuthentication.SetAuthCookie(usuario.USU_C_NOME, false);
                                if (Url.IsLocalUrl(returnUrl)
                                && returnUrl.Length > 1
                                && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//")
                                && returnUrl.StartsWith("/\\"))
                                {
                                    return Redirect(returnUrl);
                                }
                                this.Session["autorizado"] = true;
                                this.Session["login"] = usuario.USU_C_NOME;
                                return RedirectToAction("Index", "Produtos");
                            }
                            else
                                ModelState.AddModelError("", "Senha informada Inválida.");
                        }
                        else
                            ModelState.AddModelError("", "Usuário sem acesso para usar o sistema.");
                    }
                    else
                        ModelState.AddModelError("", "Usuário inválido.");
                }
            }
            return View("index");
        }
    }
}