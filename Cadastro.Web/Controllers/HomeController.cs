using Cadastro.Dominio.Comandos.Entrada;
using Cadastro.Dominio.Comandos.Manipuladores;
using Cadastro.Dominio.Comandos.Resultados;
using Cadastro.Dominio.Repositorios;
using System;
using System.Web.Mvc;

namespace Cadastro.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPessoaRepositorio _repositorioPessoa;
        private readonly RegistroPessoaManipuladorComando _registroPessoa;
    


        public HomeController(IPessoaRepositorio repositorioPessoa, RegistroPessoaManipuladorComando registroPessoa)
        {
            _repositorioPessoa = repositorioPessoa;
            _registroPessoa = registroPessoa;
       
        }


        // GET: Pessoa
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult GetData()
        {
            var list = _repositorioPessoa.ListarTodos();
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RegistroPessoaComando pessoa)
        {
            var notificacoes = (RegistroPessoaResultadoComando)_registroPessoa.manipulador(pessoa);

            if (_registroPessoa.Notifications.Count > 0)
            {
                foreach (var n in _registroPessoa.Notifications)
                {
                    ViewBag.Erros += n.Message;
                }
                return View(pessoa);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Guid id)
        {
            
            return View(_repositorioPessoa.BuscarPorId(id));

        }
        [HttpPost]
        public ActionResult Edit(EditarPessoaComando pessoa)
        {
           _registroPessoa.manipulador(pessoa);
            return RedirectToAction("Index");
        }

    }
}