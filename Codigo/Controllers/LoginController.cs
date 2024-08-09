using ByGrace.Classes;
using ByGrace.IRepositorio;
using ByGrace.Model;
using ByGrace.Servicos;
using ByGrace.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ByGrace.Controllers
{
    public class LoginController : ControllerBase
    {
        public LoginController(IRepositorioTrabalho loginRepositorio) : base(loginRepositorio) 
        {
        }

        public IActionResult Index() {
            ClienteServico clienteServico = new ClienteServico(Contexto);
            Cliente cliente = clienteServico.listarPorEmail(HttpContext.Session.GetString("_emailCliente"));

            if (cliente != null)
            {
                return RedirectToAction("Index", "/Produto");
            }

            return View();
        }

        public JsonResult Logar(String email, String senha)
        {
            IClienteServico clienteServico = new ClienteServico(Contexto);
            Cliente cliente = clienteServico.logar(email, senha);

            if (cliente.CpfCliente != null)
            {
                ModelBase modelBase = new ModelBase(cliente);
                HttpContext.Session.SetString("_emailCliente", email);
            }

            return Json(new { cliente });
        }

        public IActionResult Logout()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("_emailCliente")))
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "/Login");
            }

            return RedirectToAction("Index", "/Produto");

        }
    }
}
