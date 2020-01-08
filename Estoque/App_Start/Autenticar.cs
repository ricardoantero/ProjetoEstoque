using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Estoque.App_Start
{
    public class Autenticar : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
           
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            bool autenticado = Convert.ToBoolean(filterContext.RequestContext.HttpContext.Session["autorizado"]);
            if(!autenticado)
            {
                var helper = new UrlHelper(filterContext.RequestContext);
                var url = helper.Action("Index", "Login");
                filterContext.Result = new RedirectResult(url);
            }
        }
    }
}