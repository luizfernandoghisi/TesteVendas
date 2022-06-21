using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TesteVendas.Models;
using TesteVendas.Persistencia;

namespace TesteVendas.Controllers
{
    public class VendaController : Controller
    {
        private VendasContext _context;

        public VendaController(VendasContext context)
        {
            _context = context;
        }
        public IActionResult Index(string busca)
        {
            //List<Venda> vendas = _context.Vendas.Include(v => v.Cliente).Include(v => v.Produto).ToList();
            List<Venda> vendas = _context.Vendas.Include(v => v.Produto).Include(v => v.Cliente).Where(v => v.Cliente.NmCliente.Contains(busca) || v.Produto.DscProduto.Contains(busca) || busca == null).ToList();
            return View(vendas);
        }
        [HttpGet]
        public IActionResult Inserir()
        {
            CarregarClientes();
            CarregarProdutos();

            return View();
        }
        public void CarregarClientes()
        {
            List<Cliente> clientes = _context.Clientes.ToList();
            ViewBag.Clientes = new SelectList(clientes, "ClienteId", "NmCliente");
        }
        public void CarregarProdutos()
        {
            List<Produto> produtos = _context.Produtos.ToList();
            ViewBag.Produtos = new SelectList(produtos, "ProdutoId", "DscProduto");
        }



        [HttpPost]
        public IActionResult Inserir(Venda venda)
        {
            venda.CalcularValorTotal(venda.VlrUnitarioVenda, venda.QtdVenda);
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            TempData["msg"] = "Venda inserida com Sucesso!";
            return RedirectToAction("Inserir");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarClientes();
            CarregarProdutos();
            Venda venda = _context.Vendas.Find(id);
            return View(venda);
        }
        [HttpPost]
        public IActionResult Editar(Venda venda)
        {
            venda.CalcularValorTotal(venda.VlrUnitarioVenda, venda.QtdVenda);
            _context.Vendas.Update(venda);
            _context.SaveChanges();
            TempData["msg"] = "Venda editada com sucesso";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Excluir(int id)
        {
            Venda venda = _context.Vendas.Find(id);
            _context.Vendas.Remove(venda);
            _context.SaveChanges();
            TempData["msgRemove"] = "Venda Excluída!";
            return RedirectToAction("Index");
        }
    }
}
