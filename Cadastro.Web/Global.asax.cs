using Cadastro.Dominio.Comandos.Manipuladores;
using Cadastro.Dominio.Repositorios;
using Cadastro.Infra.Contexto;
using Cadastro.Infra.Repositorio;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cadastro.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            
            container.Register<IPessoaRepositorio, RepositorioPessoa>();
            container.Register<RegistroPessoaManipuladorComando>();
            container.Register<IDb, SqlServer>();


            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}
