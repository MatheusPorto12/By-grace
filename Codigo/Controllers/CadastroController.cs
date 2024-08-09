using ByGrace.Classes;
using ByGrace.IRepositorio;
using ByGrace.Servicos.Interfaces;
using ByGrace.Servicos;
using Microsoft.AspNetCore.Mvc;
using ByGrace.Model;

namespace ByGrace.Controllers
{
    public class CadastroController : ControllerBase
    {

        public CadastroController(IRepositorioTrabalho cadastroRepositorio) : base(cadastroRepositorio)
        {
        }

        public IActionResult Index()
        {
            ClienteServico clienteServico = new ClienteServico(Contexto);
            Cliente cliente = clienteServico.listarPorEmail(HttpContext.Session.GetString("_emailCliente"));

            if (cliente != null)
            {
                return RedirectToAction("Index", "/Produto");
            }

            return View();
        }

        public  JsonResult Cadastrar(Cliente cliente)
        {
            IClienteServico clienteServico = new ClienteServico(Contexto);
            cliente.DataCadastro = DateTime.Now;
            try
            {
                clienteServico.incluir(cliente);
            }catch (Exception ex)
            {
                return Json(new
                {
                    mensagem = "Erro ao Incluir cliente.",
                });
                throw;
            }

            return Json(new { cliente });
        }
    }
}
