using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Estoque
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
              name: "Login",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
          );

            #region Produtos
            routes.MapRoute(
               name: "ProdutosIndex",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Produtos", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "ProdutosEdit",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Produtos", action = "Edit", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "ProdutosDetails",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Produtos", action = "Details", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "ProdutosDelete",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Produtos", action = "Delete", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "ProdutosCreate",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Produtos", action = "Create", id = UrlParameter.Optional }
         );
            #endregion

            #region Usuarios
            routes.MapRoute(
              name: "UsuariosIndex",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Usuarios", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "UsuariosEdit",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Usuarios", action = "Edit", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "UsuariosDetails",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Usuarios", action = "Details", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "UsuariosDelete",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Usuarios", action = "Delete", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "UsuariosCreate",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Usuarios", action = "Create", id = UrlParameter.Optional }
         );

        #endregion

           
        }
    }
}
