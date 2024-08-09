using ByGrace.Classes.Comum;
using ByGrace.Classes;
using Microsoft.AspNetCore.Mvc;
using ByGrace.Servicos.Interfaces;
using ByGrace.Servicos;
using ByGrace.Data;
using ByGrace.Model;
using ByGrace.IRepositorio;

namespace ByGrace.Controllers;

public class ProdutoController : ControllerBase
{
    public ProdutoController(IRepositorioTrabalho produtosRepositorio) : base(produtosRepositorio)
    {
    }

    public IActionResult Incluir()
    {

        var objModel = new ProdutosModel();

        objModel.Tamanhos = Rotinas.RetornarListaEnum(typeof(Constantes.Constantes.Tamanhos));
        objModel.Categoria = Rotinas.RetornarListaEnum(typeof(Constantes.Constantes.CategoriaProduto));

        return View(objModel);
    }

    public IActionResult Index(int categoria = -1)
    {
        ProdutosServico produtoServico = new ProdutosServico(Contexto);
        ClienteServico clienteServico = new ClienteServico(Contexto);
        var objModel = new ProdutosModel();

        Cliente cliente = clienteServico.listarPorEmail(HttpContext.Session.GetString("_emailCliente"));

        if (cliente != null)
        {
            objModel.TipoCliente = cliente.TipoCliente;

            if(cliente.TipoCliente == Constantes.Constantes.TipoCliente.Administrador)
            {
                objModel.ProdutosLista = produtoServico.ListarTodos(categoria).ToList();
            } else
            {
                objModel.ProdutosLista = produtoServico.ListarDisponiveis(categoria).ToList();
            }

        } else
        {
            objModel.TipoCliente = (Constantes.Constantes.TipoCliente)1;
            objModel.ProdutosLista = produtoServico.ListarDisponiveis(categoria).ToList();
        }

        return View(objModel);
    }

    public IActionResult Alterar(int id)
    {
        ClienteServico clienteServico = new ClienteServico(Contexto);
        Cliente cliente = clienteServico.listarPorEmail(HttpContext.Session.GetString("_emailCliente"));

        if(cliente == null)
        {
            return RedirectToAction("Index", "/Login");
        }

        if(cliente.TipoCliente != Constantes.Constantes.TipoCliente.Administrador)
        {
            return RedirectToAction("Index", "/Produto");
        }

        ProdutosServico produtoServico = new ProdutosServico(Contexto);
        var objModel = new ProdutosModel();

        objModel.Produto = produtoServico.ListarPorCodigo(id);
        objModel.Tamanhos = Rotinas.RetornarListaEnum(typeof(Constantes.Constantes.Tamanhos));
        objModel.Categoria = Rotinas.RetornarListaEnum(typeof(Constantes.Constantes.CategoriaProduto));

        return View(objModel);
    }

    public IActionResult Detalhes(int id) {

        ProdutosServico produtoServico = new ProdutosServico(Contexto);
        var objModel = new ProdutosModel();

        Produtos prod = produtoServico.ListarPorCodigo(id);

        objModel.Produto = prod;
        objModel.Tamanhos = Rotinas.RetornarListaEnum(typeof(Constantes.Constantes.Tamanhos));
        objModel.ProdutosLista = produtoServico.ListarTodos((int)prod.CategoriaProduto);

        return View(objModel);
    }

    [HttpGet]
    public IActionResult ObterImagem(int id)
    {

        ProdutosServico produtoServico = new ProdutosServico(Contexto);
        var produto = produtoServico.ListarPorCodigo(id);

        if (produto == null || produto.FotoProduto == null)
        {
            return NotFound();
        }

        return File(produto.FotoProduto, "image/jpeg");
    }

    public JsonResult SalvarProduto(ProdutosModel objModel, IFormFile imageFile)
    {
        ProdutosServico produtoServico = new ProdutosServico(Contexto);

        if (imageFile != null && imageFile.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                objModel.Produto.FotoProduto = memoryStream.ToArray();
            }
        }else
        {
            Produtos prod = produtoServico.ListarPorCodigo(objModel.Produto.CodigoProduto);
            objModel.Produto.FotoProduto = prod.FotoProduto;
            objModel.Produto.DataCadastroProduto = prod.DataCadastroProduto;
        }

        
        if (objModel.Produto.CodigoProduto == 0)
        {
            objModel.Produto.DataCadastroProduto = DateTime.Now;

            try
            {
                produtoServico.Incluir(objModel.Produto);
            }
            catch (Exception)
            {
                return Json(new
                {
                    mensagem = "Erro ao Incluir produto.",
                });
                throw;
            }

            return Json(new
            {
                mensagem = "Produto cadastrado com sucesso!",
            });
        } else {
            try
            {
                produtoServico.Atualizar(objModel.Produto);
            }
            catch (Exception)
            {
                return Json(new
                {
                    mensagem = "Erro ao alterar produto.",
                });
                throw;
            }

            return Json(new
            {
                mensagem = "Produto "+ objModel.Produto.CodigoProduto +" atualizado com sucesso!",
            });
        }    

        

    }

    public JsonResult ExcluirProduto(int codigoProduto)
    {

        ProdutosServico produtoServico = new ProdutosServico(Contexto);

        try
        {
            produtoServico.Excluir(codigoProduto);
        }
        catch (Exception)
        {
            return Json(new
            {
                mensagem = "Erro ao excluir produto!",
            });
            throw;
        }


        return Json(new
        {
            mensagem = "Produto excluído com sucesso!",
        });

    }
}
