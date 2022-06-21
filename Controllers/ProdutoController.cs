using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TesteVendas.Models;
using TesteVendas.Persistencia;

namespace TesteVendas.Controllers
{
    public class ProdutoController : Controller
    {
        private VendasContext _context;

        public ProdutoController(VendasContext context)
        {
            _context = context;
        }
        public IActionResult Index(string dscBusca)
        {
            List<Produto> produtos = _context.Produtos.Where(p => p.DscProduto.Contains(dscBusca) || dscBusca == null).ToList();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Inserir()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Inserir(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            TempData["msg"] = "Venda inserida com Sucesso!";
            return RedirectToAction("Inserir");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Produto produto = _context.Produtos.Find(id);
            return View(produto);
        }
        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            TempData["msg"] = "Produto editado com sucesso";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Excluir(int id)
        {
            Produto produto = _context.Produtos.Find(id);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            TempData["msgRemove"] = "Produto Excluído!";
            return RedirectToAction("Index");
        }

    }
}
